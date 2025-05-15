using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Linq;
using DevionGames.StatSystem.Configuration;

namespace DevionGames.StatSystem
{
    public class StatsManager : MonoBehaviour
    {
        private static StatsManager m_Current;

        /// <summary>
        /// The StatManager singleton object. This object is set inside Awake()
        /// </summary>
        public static StatsManager current
        {
            get
            {
                Assert.IsNotNull(m_Current, "Requires a Stats Manager.Create one from Tools > Devion Games > Stat System > Create Stats Manager!");
                return m_Current;
            }
        }

        [SerializeField]
        private StatDatabase m_Database = null;

        /// <summary>
        /// Gets the item database. Configurate it inside the editor.
        /// </summary>
        /// <value>The database.</value>
        public static StatDatabase Database
        {
            get
            {
                if (StatsManager.current != null)
                {
                    Assert.IsNotNull(StatsManager.current.m_Database, "Please assign StatDatabase to the Stats Manager!");
                    return StatsManager.current.m_Database;
                }
                return null;
            }
        }

        private static Default m_DefaultSettings;
        public static Default DefaultSettings
        {
            get
            {
                if (m_DefaultSettings == null)
                {
                    m_DefaultSettings = GetSetting<Default>();
                }
                return m_DefaultSettings;
            }
        }

        private static UI m_UI;
        public static UI UI
        {
            get
            {
                if (m_UI == null)
                {
                    m_UI = GetSetting<UI>();
                }
                return m_UI;
            }
        }

        private static Notifications m_Notifications;
        public static Notifications Notifications
        {
            get
            {
                if (m_Notifications == null)
                {
                    m_Notifications = GetSetting<Notifications>();
                }
                return m_Notifications;
            }
        }

        private static SavingLoading m_SavingLoading;
        public static SavingLoading SavingLoading
        {
            get
            {
                if (m_SavingLoading == null)
                {
                    m_SavingLoading = GetSetting<SavingLoading>();
                }
                return m_SavingLoading;
            }
        }

        private static T GetSetting<T>() where T : Configuration.Settings
        {
            if (StatsManager.Database != null)
            {
                return (T)StatsManager.Database.settings.Where(x => x.GetType() == typeof(T)).FirstOrDefault();
            }
            return default(T);
        }

        /// Don't destroy this object instance when loading new scenes.
        /// </summary>
        public bool dontDestroyOnLoad = true;

        private List<StatsHandler> m_StatsHandler;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            if (StatsManager.m_Current != null)
            {
                // Debug.Log("Multiple Stat Manager in scene...this is not supported. Destroying instance!");
                Destroy(gameObject);
                return;
            }
            else
            {
                StatsManager.m_Current = this;
                if (dontDestroyOnLoad)
                {
                    if (transform.parent != null)
                    {
                        if (StatsManager.DefaultSettings.debugMessages)
                            Debug.Log("Stats Manager with DontDestroyOnLoad can't be a child transform. Unparent!");
                        transform.parent = null;
                    }
                    DontDestroyOnLoad(gameObject);
                }

                this.m_StatsHandler = new List<StatsHandler>();
                if (StatsManager.SavingLoading.autoSave)
                {
                    StartCoroutine(RepeatSaving(StatsManager.SavingLoading.savingRate));
                }
                if (StatsManager.DefaultSettings.debugMessages)
                    Debug.Log("Stats Manager initialized.");
            }
        }

        private void Start()
        {
            if (StatsManager.SavingLoading.autoSave)
            {
                StartCoroutine(DelayedLoading(1f));
            }
        }


        public static void Save()
        {
            string key = PlayerPrefs.GetString(StatsManager.SavingLoading.savingKey, StatsManager.SavingLoading.savingKey);
            Save(key);
        }

        public static void Save(string key)
        {
            // Top-level save call
            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log("[StatsManager] Save() called");

            // Find all saveable handlers
            // Unity 2023.2+ replacement for FindObjectsOfType
            StatsHandler[] results = Object.FindObjectsByType<StatsHandler>(
                    FindObjectsInactive.Include,      // include disabled handlers too
                    FindObjectsSortMode.None          // no sorting overhead
                )
                .Where(x => x.saveable)
                .ToArray();

            if (results.Length == 0)
            {
                if (StatsManager.DefaultSettings.debugMessages)
                    Debug.Log("[StatsManager] No saveable handlers found. Aborting Save().");
                return;
            }

            // JSON-serialize entire handlers list
            string data = JsonSerializer.Serialize(results);
            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log($"[StatsManager] Serialized JSON: {data}");

            // Write out each handler and each stat
            foreach (StatsHandler handler in results)
            {
                if (StatsManager.DefaultSettings.debugMessages)
                    Debug.Log($"[StatsManager]   → Saving handler '{handler.HandlerName}'");

                foreach (Stat stat in handler.m_Stats)
                {
                    // Always save the final Value
                    float statValue = stat.Value;
                    PlayerPrefs.SetFloat($"{key}.Stats.{handler.HandlerName}.{stat.Name}.Value", statValue);
                    if (StatsManager.DefaultSettings.debugMessages)
                        Debug.Log($"[StatsManager]      • {stat.Name}.Value = {statValue}");

                    // If it’s an Attribute, also save CurrentValue
                    if (stat is Attribute attribute)
                    {
                        float cv = attribute.CurrentValue;
                        PlayerPrefs.SetFloat($"{key}.Stats.{handler.HandlerName}.{stat.Name}.CurrentValue", cv);
                        if (StatsManager.DefaultSettings.debugMessages)
                            Debug.Log($"[StatsManager]      • {stat.Name}.CurrentValue = {cv}");
                    }
                }
            }

            // Finally, save the JSON blob and update key list
            PlayerPrefs.SetString($"{key}.Stats", data);
            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log($"[StatsManager] JSON stored under key '{key}.Stats'");

            // Maintain the saved-keys registry
            List<string> keys = PlayerPrefs.GetString("StatSystemSavedKeys")
                                           .Split(';')
                                           .Where(x => !string.IsNullOrEmpty(x))
                                           .ToList();
            if (!keys.Contains(key)) keys.Add(key);
            PlayerPrefs.SetString("StatSystemSavedKeys", string.Join(";", keys));

            PlayerPrefs.Save();
            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log("[StatsManager] Save() complete");
        }


        public static void Load()
        {
            string key = PlayerPrefs.GetString(StatsManager.SavingLoading.savingKey, StatsManager.SavingLoading.savingKey);
            Load(key);
        }

        public static void Load(string key)
        {
            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log("[StatsManager] Load() called");

            // Read the JSON blob
            string data = PlayerPrefs.GetString($"{key}.Stats");
            if (string.IsNullOrEmpty(data))
            {
                if (StatsManager.DefaultSettings.debugMessages)
                    Debug.Log($"[StatsManager] No JSON found under key '{key}.Stats', aborting Load().");
                return;
            }
            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log($"[StatsManager] JSON loaded: {data}");

            // Find all active saveable handlers
            List<StatsHandler> results = Object.FindObjectsByType<StatsHandler>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None
                )
                .Where(x => x.saveable)
                .ToList();

            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log($"[StatsManager] → Found {results.Count} saveable handlers in scene");

            // Deserialize and apply
            List<object> list = MiniJSON.Deserialize(data) as List<object>;
            for (int i = 0; i < list.Count; i++)
            {
                var handlerData = list[i] as Dictionary<string, object>;
                string handlerName = handlerData["Name"] as string;
                if (StatsManager.DefaultSettings.debugMessages)
                    Debug.Log($"[StatsManager]   → Restoring handler '{handlerName}'");

                StatsHandler handler = results.Find(x => x.HandlerName == handlerName);
                if (handler != null)
                {
                    handler.SetObjectData(handlerData);
                }
                else if (StatsManager.DefaultSettings.debugMessages)
                {
                    Debug.LogWarning($"[StatsManager]   ✗ No handler with Name '{handlerName}' found in scene");
                }
            }

            if (StatsManager.DefaultSettings.debugMessages)
                Debug.Log("[StatsManager] Load() complete");
        }




        private IEnumerator DelayedLoading(float seconds)
        {
            yield return new WaitForSecondsRealtime(seconds);
            try
            {
                Load();
                if (DefaultSettings.debugMessages)
                    Debug.Log("[StatsManager] Initial Load() completed without errors");
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"[StatsManager] suppressed exception during initial Load(): {e.Message}");
            }
        }


        private IEnumerator RepeatSaving(float seconds)
        {
            while (true)
            {
                yield return new WaitForSeconds(seconds);
                Save();
            }
        }

        public static void RegisterStatsHandler(StatsHandler handler)
        {
            if (!StatsManager.current.m_StatsHandler.Contains(handler))
            {
                StatsManager.current.m_StatsHandler.Add(handler);
            }
        }

        public static StatsHandler GetStatsHandler(string name)
        {
            return StatsManager.current.m_StatsHandler.Find(x => x.HandlerName == name);
        }

    }
}