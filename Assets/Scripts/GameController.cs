using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ActionRecorder actionRecorder;
    public NPCController npcController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            List<ActionData> recordedActions = actionRecorder.GetRecordedActions();

            Debug.Log("Entrou");

            // Passe as ações gravadas para o NPCController
            npcController.SetRecordedActions(recordedActions);
        }
    }
}

