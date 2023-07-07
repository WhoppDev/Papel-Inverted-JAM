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
        // Obt�m os inputs horizontais e verticais
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula a dire��o do movimento
        Vector2 direcao = new Vector2(movimentoHorizontal, movimentoVertical);

        // Normaliza a dire��o para garantir um movimento suave em todas as dire��es
        direcao.Normalize();

        // Calcula o vetor de deslocamento multiplicando a dire��o pelo tempo e pela velocidade
        Vector2 deslocamento = direcao * velocidade * Time.deltaTime;

        // Move o objeto na dire��o calculada
        transform.Translate(deslocamento);

        actionRecorder.RecordAction(transform.position, transform.rotation, Time.time, "Move");
    }

}
