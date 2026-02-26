using UnityEngine;

public class DemoLogBootstrap : MonoBehaviour
{
    const string DemoObjectName = "[Demo Logs]";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void EnsureDemoObjectInScene()
    {
        if (HasBootstrapInScene())
        {
            return;
        }

        var demoObject = new GameObject(DemoObjectName);
        demoObject.AddComponent<DemoLogBootstrap>();
        demoObject.AddComponent<DemoSimpleLog>();
        demoObject.AddComponent<DemoWarningErrorLog>();
        demoObject.AddComponent<DemoPeriodicLog>();
        demoObject.AddComponent<DemoInputLog>();
    }

    void Awake()
    {
        EnsureComponent<DemoSimpleLog>();
        EnsureComponent<DemoWarningErrorLog>();
        EnsureComponent<DemoPeriodicLog>();
        EnsureComponent<DemoInputLog>();

        DontDestroyOnLoad(gameObject);
        Debug.Log("DemoLogBootstrap created demo logger object.", this);
    }

    static bool HasBootstrapInScene()
    {
#if UNITY_2023_1_OR_NEWER
        return Object.FindFirstObjectByType<DemoLogBootstrap>() != null;
#else
        return Object.FindObjectOfType<DemoLogBootstrap>() != null;
#endif
    }

    void EnsureComponent<T>() where T : Component
    {
        if (GetComponent<T>() == null)
        {
            gameObject.AddComponent<T>();
        }
    }
}
