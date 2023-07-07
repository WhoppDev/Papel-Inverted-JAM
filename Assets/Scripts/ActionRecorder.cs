using System.Collections.Generic;
using UnityEngine;

public struct ActionData
{
    public Vector3 position;
    public Quaternion rotation;
    public float time;
    public string action;
}

public class ActionRecorder : MonoBehaviour
{
    private List<ActionData> actions = new List<ActionData>();

    public void RecordAction(Vector3 position, Quaternion rotation, float time, string action)
    {
        ActionData data;
        data.position = position;
        data.rotation = rotation;
        data.time = time;
        data.action = action;
        actions.Add(data);
    }

    public List<ActionData> GetRecordedActions()
    {
        return actions;
    }
}
