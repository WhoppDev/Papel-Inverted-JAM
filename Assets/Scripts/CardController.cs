using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int xp;
    [SerializeField] private int streght;
    [SerializeField] private int speed;
    [SerializeField] private GameObject[] Prefab;

    public GameObject canvasobject;

    private SpawnController drop;

    [SerializeField] private GameObject SpawnPoint;





    // Start is called before the first frame update
    void Start()
    {
        drop = FindAnyObjectByType<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!drop.SpawnSelected == null)
        {
            switch (drop.SpawnSelected.name)
            {
                case "Card1":
                    print("testeeeeeee");
                    Instantiate(Prefab[0], drop.SpawnSelected.transform);
                    break;
            }
        }

    }
}
