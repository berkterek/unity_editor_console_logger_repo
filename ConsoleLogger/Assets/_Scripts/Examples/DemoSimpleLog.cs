using UnityEngine;

public class DemoSimpleLog : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("DemoSimpleLog: OnEnable called.", this);
    }

    void Start()
    {
        Debug.Log("DemoSimpleLog: Start called.", this);
    }

    void OnDisable()
    {
        Debug.Log("DemoSimpleLog: OnDisable called.", this);
    }
}
