using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public string npcName; // Nome do NPC
    public int requiredXP; // XP necessário para chamar o NPC
    public GameObject npcPrefab;
    public string descrição;
    public float streght;
    public float speed;
    public int life;

}
