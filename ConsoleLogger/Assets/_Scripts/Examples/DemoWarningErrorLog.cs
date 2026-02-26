using System.Collections;
using UnityEngine;

public class DemoWarningErrorLog : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.LogWarning("DemoWarningErrorLog: This is a warning sample.", this);

        yield return new WaitForSeconds(0.4f);
        Debug.LogError("DemoWarningErrorLog: This is an error sample.", this);
    }
}
