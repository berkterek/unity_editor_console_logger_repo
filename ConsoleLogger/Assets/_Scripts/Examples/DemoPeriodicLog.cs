using UnityEngine;

public class DemoPeriodicLog : MonoBehaviour
{
    [SerializeField] float intervalSeconds = 1f;
    [SerializeField] int totalLogs = 5;

    float elapsed;
    int logCount;

    void Update()
    {
        if (logCount >= totalLogs)
        {
            return;
        }

        elapsed += Time.deltaTime;
        if (elapsed < intervalSeconds)
        {
            return;
        }

        elapsed = 0f;
        logCount++;
        Debug.Log($"DemoPeriodicLog: Tick {logCount}/{totalLogs}", this);
    }
}
