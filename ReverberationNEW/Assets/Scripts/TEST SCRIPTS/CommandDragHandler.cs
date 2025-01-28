using UnityEngine;
using UnityEngine.EventSystems;

public class CommandDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    // Add this field to hold the Command data for this dragged object
    public Command commandData; 

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false; // Allow dragging without interference
        transform.SetParent(transform.root); // Make it float above UI
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == transform.root) // Return to original position if not dropped on drop zone
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }
    }
}
