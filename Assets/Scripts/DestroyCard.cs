using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCard : MonoBehaviour
{
    [SerializeField] private DragDrop drop;
    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponentInChildren<DragDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drop.isUsed == true)
        {
            Destroy(gameObject);
        }
    }
}
