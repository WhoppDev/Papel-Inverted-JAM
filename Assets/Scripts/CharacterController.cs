using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidade = 5f;
    
    public Transform[] ponto;

    [SerializeField] private int indice;

    //public GameObject location;

    private void Start()
    {
        indice = 0;
    }

    private void Update()
    {
        if(indice < ponto.Length)
        {
            Move();
        }

    }

    private void Move()
    {
        Vector2 distancia = ponto[indice].position - transform.position;

        distancia.Normalize();

        Vector2 targetPosition = (Vector2)transform.position + distancia * velocidade * Time.deltaTime;

        transform.position = targetPosition;
    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.tag == "Point") {

            if(indice == ponto.Length ) {

                print("Acabou");

            } 

            indice++;




        }

    }

}
