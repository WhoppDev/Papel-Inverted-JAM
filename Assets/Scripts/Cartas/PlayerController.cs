using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;

    [SerializeField] private Animator animator;

    [SerializeField] private int indice;

    public List<Transform> ponto = new List<Transform>();

    public float stopDistance = 3f;

    public bool isViewing = false;

    public Vector2 distancia;

    public GameObject torre;

    //public GameObject location;

    private void Start()
    {
        indice = 0;
        ponto = new List<Transform>();

        animator = GetComponent<Animator>();

        ponto.Add(GameObject.Find("MovePoint1").transform);
        ponto.Add(GameObject.Find("MovePoint2").transform);
        ponto.Add(GameObject.Find("MovePoint3").transform);
        ponto.Add(GameObject.Find("MovePoint4").transform);
        ponto.Add(GameObject.Find("MovePoint5").transform);
        ponto.Add(GameObject.Find("MovePoint6").transform);
        ponto.Add(GameObject.Find("MovePoint7").transform);

    }

    private void Update()
    {
        if(indice < ponto.Count)
        {
            Move();

        } else if (indice == ponto.Count){
            
            print("Acabou");
            indice = ponto.Count+1;

        }

        animator.SetFloat("Horizontal", transform.position.x);
        animator.SetFloat("Vertical", transform.position.y);
        animator.SetFloat("Speed", speed);

    }

    private void Move()
    {
        Vector2 distancia = Vector2.zero; // Inicializa a variável distancia com um valor inicial

        if (isViewing == false)
        {
            distancia = ponto[indice].position - transform.position;
        }
        else if (isViewing == true)
        {
            distancia = torre.transform.position - transform.position;
        }

        distancia.Normalize();

        Vector2 targetPosition = (Vector2)transform.position + distancia * speed * Time.deltaTime;

        float distanceMagnitude = (targetPosition - (Vector2)transform.position).magnitude;

        if (distanceMagnitude > stopDistance)
        {
            transform.position = targetPosition;
        }
    }





    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.tag == "Point") {

            indice++;

        }

        if(collider.gameObject.tag == "Torre") {

            isViewing = true;
            torre = collider.gameObject;
            //Destroy(torre, 2f);
            //torre.GetComponent<CircleCollider2D>().enabled = false;

        }

    }

    void OnTriggerExit2D (Collider2D collider) {

        if(collider.gameObject.tag == "Torre") {

            isViewing = false;

        }
    }

}
