using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public Transform monstro1;

    public float velocidade;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 distance = monstro1.position - transform.position;

        distance.Normalize();

        Vector2 posicaoAlvo = (Vector2)transform.position + distance * velocidade * Time.deltaTime;

        transform.position = posicaoAlvo;

    }
}
