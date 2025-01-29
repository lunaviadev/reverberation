using UnityEngine;
using UnityEngine.EventSystems;

public class CommandDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    public Command commandData;
    public Vector3 originalPosition;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == transform.root)
        {
            transform.SetParent(originalParent);
            transform.localPosition = originalPosition;
        }
    }

    public void SetCommandData(DropBox.MovementCommands commandType)
    {
        string action = "";

        switch (commandType)
        {
            case DropBox.MovementCommands.MoveLeft:
                action = "MoveLeft";
                break;
            case DropBox.MovementCommands.MoveRight:
                action = "MoveRight";
                break;
            case DropBox.MovementCommands.MoveUp:
                action = "MoveUp";
                break;
            case DropBox.MovementCommands.MoveUpLeft:
                action = "MoveUpLeft";
                break;
            case DropBox.MovementCommands.MoveUpRight:
                action = "MoveUpRight";
                break;
            default:
                action = "Unknown";
                break;
        }
        commandData = new Command(action, commandType);
    }
}
