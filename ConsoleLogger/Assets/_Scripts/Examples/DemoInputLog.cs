using System;
using UnityEngine;

public class DemoInputLog : MonoBehaviour
{
    void Start()
    {
        Debug.Log("DemoInputLog ready. Press Space=Log, W=Warning, E=Error, X=Exception.", this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DemoInputLog: Space pressed.", this);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.LogWarning("DemoInputLog: W pressed.", this);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.LogError("DemoInputLog: E pressed.", this);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.LogException(new InvalidOperationException("DemoInputLog: X pressed -> sample exception."), this);
        }
    }
}
