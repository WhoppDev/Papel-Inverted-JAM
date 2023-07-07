using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidade = 5f;

    [SerializeField] private ActionRecorder actionRecorder;

    private void Start()
    {
        actionRecorder = FindObjectOfType<ActionRecorder>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Obtém os inputs horizontais e verticais
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula a direção do movimento
        Vector2 direcao = new Vector2(movimentoHorizontal, movimentoVertical);

        // Normaliza a direção para garantir um movimento suave em todas as direções
        direcao.Normalize();

        // Calcula o vetor de deslocamento multiplicando a direção pelo tempo e pela velocidade
        Vector2 deslocamento = direcao * velocidade * Time.deltaTime;

        // Move o objeto na direção calculada
        transform.Translate(deslocamento);

        actionRecorder.RecordAction(transform.position, transform.rotation, Time.time, "Move");
    }

}
