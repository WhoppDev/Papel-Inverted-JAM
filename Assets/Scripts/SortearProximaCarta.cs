using UnityEngine;

public class SortearProximaCarta : MonoBehaviour
{
    public GameObject[] objetosArray; // Array de objetos
    public GameObject objetoPrefab; // Prefab do objeto a ser criado

    public GameObject[] cartas;
    public GameObject spawnCartas;

    void Start()
    {
        // Inicializa o array com os objetos existentes no início do jogo
        objetosArray = new GameObject[3];
        for (int i = 0; i < objetosArray.Length; i++)
        {
            objetosArray[i] = CriarObjeto();
        }
    }

    void Update()
    {
        // Verifica se algum objeto foi destruído pelo jogador
        for (int i = 0; i < objetosArray.Length; i++)
        {
            if (objetosArray[i] == null)
            {
                // Se o objeto foi destruído, cria um novo objeto no array
                objetosArray[i] = CriarObjeto();
            }
        }
    }

    GameObject CriarObjeto()
    {
        int index = Random.Range(0, cartas.Length);

        // Cria um novo objeto a partir do prefab
        GameObject novoObjeto = Instantiate(cartas[index], spawnCartas.transform);
        // Realize qualquer configuração adicional que você precisar para o novo objeto aqui
        return novoObjeto;
    }
}
