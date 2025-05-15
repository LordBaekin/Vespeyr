// File: FlowManager.cs
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Coherence.Toolkit;   // CoherenceBridge, CoherenceBridgeStore
using Coherence.Cloud;     // CloudService, WorldData

public class FlowManager : MonoBehaviour
{
    // Singleton instance
    public static FlowManager Instance { get; private set; }

    [Header("Splash Configuration")]
    [Tooltip("RawImage component on your splash panel where textures will be shown")]
    public RawImage splashDisplay;
    [Tooltip("List of textures to cycle on splash")]
    public List<Texture> splashTextures = new List<Texture>();
    [Tooltip("Seconds to show each splash image")]
    public float splashInterval = 5f;

    [Header("Panels")]
    public GameObject splashPanel;
    public GameObject loginPanel;
    public GameObject serverPanel;

    [Header("Login UI")]
    public Button loginButton;
    public InputField usernameInput;
    public InputField passwordInput;

    [Header("World/Server Selection UI")]
    public RectTransform listContent;
    public GameObject entryPrefab;
    public Button backButton;
    public Button nextButton;

    [Header("Scenes")]
    [Tooltip("Name of the scene that hosts your SelectCharacterWindow prefab")]
    public string selectCharacterScene = "Select Character";
    [Tooltip("Name of your main gameplay scene")]
    public string mainScene = "Main";

    private CoherenceBridge _bridge;
    private WorldData _chosenWorld;

    void Awake()
    {
        // Enforce singleton and persist across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("[FlowManager] Awake()");
        if (!CoherenceBridgeStore.TryGetBridge(gameObject.scene, out _bridge) || _bridge == null)
            _bridge = CoherenceBridgeStore.MasterBridge;
        if (_bridge == null)
            Debug.LogError("[FlowManager] No CoherenceBridge available.");
        else
            _bridge.onConnected.AddListener(b => Debug.Log($"[FlowManager] Coherence connected. ClientID={b.ClientID}"));
    }

    void Start()
    {
        Debug.Log("[FlowManager] Start()");
        ShowOnly(splashPanel);
        StartCoroutine(SplashSequence());

        loginButton.onClick.AddListener(OnLoginClicked);
        backButton.onClick.AddListener(() => { Debug.Log("[FlowManager] Back to Login"); ShowOnly(loginPanel); });
        nextButton.onClick.AddListener(OnNextClicked);
        nextButton.interactable = false;
    }

    IEnumerator SplashSequence()
    {
        Debug.Log("[FlowManager] SplashSequence begin");
        if (splashDisplay == null || splashTextures.Count == 0)
        {
            Debug.LogWarning("[FlowManager] No splash images assigned");
            yield return null;
        }
        else
        {
            for (int i = 0; i < splashTextures.Count; i++)
            {
                Debug.Log($"[FlowManager] Showing splash {i + 1}/{splashTextures.Count}");
                splashDisplay.texture = splashTextures[i];
                float elapsed = 0f;
                while (elapsed < splashInterval)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Debug.Log($"[FlowManager] Skipping splash {i + 1}");
                        yield return null;
                        break;
                    }
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }
        Debug.Log("[FlowManager] SplashSequence complete, showing Login");
        ShowOnly(loginPanel);
    }

    public void ShowOnly(GameObject panel)
    {
        splashPanel.SetActive(false);
        loginPanel.SetActive(false);
        serverPanel.SetActive(false);
        panel.SetActive(true);
    }

    public Task PopulateServersAsync() => ListWorlds();

    async void OnLoginClicked()
    {
        var user = usernameInput.text.Trim();
        Debug.Log($"[FlowManager] OnLoginClicked: '{user}'");
        ShowOnly(serverPanel);
        nextButton.interactable = false;
        ClearList();

        try { await ListWorlds(); }
        catch (System.Exception e) { Debug.LogError($"[FlowManager] Error fetching worlds: {e}"); }
    }

    void ClearList()
    {
        foreach (Transform child in listContent)
            Destroy(child.gameObject);
    }

    async Task ListWorlds()
    {
        Debug.Log("[FlowManager] ListWorlds()");
        var cloud = _bridge.CloudService;
        if (cloud == null) { Debug.LogError("[FlowManager] CloudService is null—check Bridge settings"); return; }
        Debug.Log("[FlowManager] Waiting for CloudService login...");
        await cloud.WaitForCloudServiceLoginAsync(1000);

        var worlds = await cloud.Worlds.FetchWorldsAsync();
        Debug.Log($"[FlowManager] Fetched {worlds.Count} worlds");
        if (worlds.Count == 0) { Debug.LogWarning("[FlowManager] No worlds available."); return; }

        for (int i = 0; i < worlds.Count; i++)
        {
            var w = worlds[i];
            var entry = Instantiate(entryPrefab, listContent);
            var txt = entry.GetComponentInChildren<Text>();
            var btn = entry.GetComponent<Button>();
            txt.text = w.Name;
            int idx = i;
            btn.onClick.AddListener(() => { _chosenWorld = worlds[idx]; nextButton.interactable = true; Debug.Log($"[FlowManager] World selected: {_chosenWorld.Name}"); });
        }
    }

    void OnNextClicked()
    {
        if (string.IsNullOrEmpty(_chosenWorld.Name)) { Debug.LogWarning("[FlowManager] No world selected."); return; }
        Debug.Log($"[FlowManager] Joining world: {_chosenWorld.Name}");
        _bridge.JoinWorld(_chosenWorld);
        Debug.Log($"[FlowManager] Loading select-character scene '{selectCharacterScene}'");
        SceneManager.LoadScene(selectCharacterScene, LoadSceneMode.Single);
    }

    public async void OnCharacterChosen(string characterName)
    {
        Debug.Log($"[FlowManager] Character confirmed: {characterName}");
        Debug.Log($"[FlowManager] Requesting load of main scene '{mainScene}'");
        SceneManager.sceneLoaded += OnSceneLoaded;
        var op = SceneManager.LoadSceneAsync(mainScene, LoadSceneMode.Single);
        while (!op.isDone) await Task.Yield();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"[FlowManager] Scene loaded: {scene.name}, mode: {mode}");
        int camCount = Camera.allCamerasCount;
        Debug.Log($"[FlowManager] Number of cameras in scene: {camCount}");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}