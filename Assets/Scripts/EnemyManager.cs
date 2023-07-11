using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Inst�ncia �nica do NPCManager

    public List<EnemyData> npcList; // Lista de NPCs dispon�veis

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
