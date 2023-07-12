using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private Vector3 startPosition; // Posi��o inicial do objeto

    private RectTransform rectTransform;
    private bool droppedOnStartCollider;
    EnemyManager enemyManager = EnemyManager.instance;

    public string _name;

    #region Atributos

    [SerializeField] private Text _xpNecess�rio;
    [SerializeField] private Text _descri��o;
    [SerializeField] private Text _Nome;


    [SerializeField] private float speed;
    [SerializeField] public float _xp;
    [SerializeField] public float streght;
    [SerializeField] public int life;
    [SerializeField] public string descri��o;

    #endregion

    public GameObject prefab;

    [SerializeField] private XP xp;


    public GameObject SpawnPoint;

    public bool isUsed;

    private void Awake()
    {
        canvas = GameObject.Find("-=-= DeckSystem").GetComponent<Canvas>();
        SpawnPoint = GameObject.Find("SpawnPoint");
        isUsed = false;
        rectTransform = GetComponent<RectTransform>();
        xp = FindAnyObjectByType<XP>();

        EnemyData enemyData = enemyManager.npcList.Find(data => data.npcName == _name);

        speed = enemyData.speed;
        streght = enemyData.streght;
        life = enemyData.life;
        _xp = enemyData.requiredXP;

        _xpNecess�rio.text = _xp.ToString();
        _descri��o.text = descri��o;
        _Nome.text = name;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Teste");

        startPosition = rectTransform.position; // Define a posi��o inicial com base na posi��o atual do objeto
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("InicioDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");

        // Verifica se o objeto foi solto em um objeto com a tag "Start"
        if (droppedOnStartCollider && xp.currentXp >= _xp)
        {
            Debug.Log("Local correto: XP atual" + xp.currentXp);
            isUsed = true;
            Instantiate(prefab, SpawnPoint.transform);
            xp.currentXp -= _xp;
        }
        else
        {
            Debug.Log("Local errado");
            rectTransform.position = startPosition; // Retorna � posi��o inicial
        }

        droppedOnStartCollider = false; // Reinicia a vari�vel para a pr�xima intera��o
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spawn"))
        {
            droppedOnStartCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Spawn"))
        {
            droppedOnStartCollider = false;
        }
    }
}
