using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private List<ActionData> recordedActions;
    private int currentActionIndex = 0;

    public void SetRecordedActions(List<ActionData> actions)
    {
        recordedActions = actions;
    }

    private void Update()
    {
        if (recordedActions != null && currentActionIndex < recordedActions.Count)
        {
            ActionData currentAction = recordedActions[currentActionIndex];
            if (currentAction.time <= Time.time)
            {
                // Execute a ação correspondente
                switch (currentAction.action)
                {
                    case "Move":
                        // Lógica de movimento
                        break;
                        // Adicione outros casos para ações adicionais
                }

                currentActionIndex++;
            }
        }
    }
}

