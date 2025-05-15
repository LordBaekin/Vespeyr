using System.Collections;
using UnityEngine;
using Coherence.Toolkit;
using UnityEngine.SceneManagement;

public class BridgeDebugger : MonoBehaviour
{
    private IEnumerator Start()
    {
        // let all bridges Awake/Start first
        yield return null;

        // use the new API—keep the default sort (InstanceID) so order is predictable
        var bridges = Object.FindObjectsByType<CoherenceBridge>(
            FindObjectsSortMode.InstanceID
        );
        Debug.Log($"[BridgeDebugger] Found {bridges.Length} CoherenceBridge(s):");
        foreach (var b in bridges)
        {
            Debug.Log(
                $"  • '{b.gameObject.name}' " +
                $"(scene='{b.Scene.name}', " +
                $"IsMain={b.IsMain}, " +
                $"AutoLoginAsGuest={b.AutoLoginAsGuest}, " +
                $"PlayerAccountAutoConnect={b.PlayerAccountAutoConnect})"
            );
        }
    }
}
