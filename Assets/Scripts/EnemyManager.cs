using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Instância única do NPCManager

    public List<EnemyData> npcList; // Lista de NPCs disponíveis

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
