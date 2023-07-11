using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float stopDistance = 3f;
    [SerializeField] private bool isViewing = false; //Se está vendo a torre
    [SerializeField] private int indice;
    [SerializeField] private Vector2 distancia;
    [SerializeField] private CannonRotate CR;

    [SerializeField] private GameObject torre; //Pegar o transform para seguir a torre
    EnemyManager enemyManager = EnemyManager.instance;
    

    public string _name;

    public List<Transform> ponto = new List<Transform>();

    #region Atributos
    [SerializeField] private float speed;
    [SerializeField] public float streght;
    [SerializeField] public int life;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        EnemyData enemyData = enemyManager.npcList.Find(data => data.npcName == _name);

        speed = enemyData.speed;
        streght = enemyData.streght;
        life = enemyData.life;

        indice = 0;

        animator = GetComponentInChildren<Animator>();

        #region Pontos Moviment
        ponto = new List<Transform>();

        ponto.Add(GameObject.Find("MovePoint1").transform);
        ponto.Add(GameObject.Find("MovePoint2").transform);
        ponto.Add(GameObject.Find("MovePoint3").transform);
        ponto.Add(GameObject.Find("MovePoint4").transform);
        ponto.Add(GameObject.Find("MovePoint5").transform);
        ponto.Add(GameObject.Find("MovePoint6").transform);
        ponto.Add(GameObject.Find("MovePoint7").transform);

        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        if (indice < ponto.Count)
        {
            Move();

        }
        else if (indice == ponto.Count)
        {

            print("Acabou");
            indice = ponto.Count + 1;

        }

        animator.SetFloat("Horizontal", transform.position.x);
        animator.SetFloat("Vertical", transform.position.y);
        animator.SetFloat("Speed", speed);

        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (indice >= 0 && indice < ponto.Count)
        {
            distancia = Vector2.zero;

            if (isViewing == false)
            {
                distancia = ponto[indice].position - transform.position;
            }
            else if (isViewing == true)
            {
                distancia = torre.transform.position - transform.position;
                Damage();
            }

            distancia.Normalize();

            Vector2 targetPosition = (Vector2)transform.position + distancia * speed * Time.deltaTime;

            // Verifica se o objeto alcançou o ponto de destino atual
            if (Vector3.Distance(transform.position, ponto[indice].position) < 0.5f)
            {
                indice++;
            }
            else
            {
                transform.position = targetPosition;
            }
        }
    }



    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Torre")
        {
            CR = collider.gameObject.GetComponent<CannonRotate>();
            torre = collider.gameObject;
            isViewing = true;

        }

        if(collider.gameObject.tag == "Bullet")
        {
            life -= 1;
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Torre")
        {

            isViewing = false;

        }
    }

    public void Damage()
    {
        CR.life -= streght * Time.deltaTime;
    }

}
