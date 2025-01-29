using UnityEngine;
using UnityEngine.EventSystems;

public class CommandDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    public Command commandData; // The Command data associated with this dragged object
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

    // Set the command data based on the selected movement command
    public void SetCommandData(DropBox.MovementCommands commandType)
    {
        string action = "";
        
        // Create the Command with the action and the movement type based on the movement command
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

        // Now create the Command object with the action and the corresponding command type
        commandData = new Command(action, commandType); // Set the action string and the command type
    }
}
