using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidade = 5f;

    public GameObject location;

    private void Start()
    {

    }

    private void Update()
    {
        Move();
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
