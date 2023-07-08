using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private Vector3 startPosition; // Posição inicial do objeto

    private RectTransform rectTransform;
    private bool droppedOnStartCollider;

    public bool isSelected;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Teste");

        startPosition = rectTransform.position; // Define a posição inicial com base na posição atual do objeto
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
        }
        else
        {
            Debug.Log("Local errado");
            rectTransform.position = startPosition; // Retorna à posição inicial
        }

        droppedOnStartCollider = false; // Reinicia a variável para a próxima interação
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
