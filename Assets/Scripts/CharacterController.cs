using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidade = 5f;
    public Transform ponto;

    private void Start()
    {

    }

    private void Update()
    {
        //Move();
        Vector2 distancia = ponto.position - transform.position;

        distancia.Normalize();
        
        Vector2 targetPosition = (Vector2)transform.position + distancia * velocidade * Time.deltaTime;

        transform.position = targetPosition;
        
    }

    private void Move()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector2 direcao = new Vector2(movimentoHorizontal, movimentoVertical);
        direcao.Normalize();

        Vector2 deslocamento = direcao * velocidade * Time.deltaTime;

        transform.Translate(deslocamento);
    }

}
