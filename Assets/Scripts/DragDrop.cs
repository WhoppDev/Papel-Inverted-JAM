using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private Vector3 startPosition; // Posi��o inicial do objeto

    private RectTransform rectTransform;
    private bool droppedOnStartCollider;

    public GameObject prefab;

    public GameObject SpawnPoint;

    private SpawnController drop;

    public bool isSelected;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        drop = FindAnyObjectByType<SpawnController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Teste");

        startPosition = rectTransform.position; // Define a posi��o inicial com base na posi��o atual do objeto
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("InicioDrag");
        isSelected = false;
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
        if (droppedOnStartCollider)
        {
            Debug.Log("Local correto");
            isSelected = true;
            Instantiate(prefab, SpawnPoint.transform);
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
