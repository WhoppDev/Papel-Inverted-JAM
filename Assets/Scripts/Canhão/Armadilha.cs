using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    
    public GameObject objeto;
    public Transform spot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player") {

            GameObject temp = Instantiate(objeto);
            temp.transform.position = new Vector3(spot.transform.position.x, spot.transform.position.y, spot.transform.position.z);
            print("Criei");

        }

    }

}
