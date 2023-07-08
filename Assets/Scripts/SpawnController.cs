using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject SpawnSelected;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            SpawnSelected = collision.gameObject;
        }
    }
}
