using UnityEngine;
using UnityEngine.EventSystems;

public class CommandDropHandler : MonoBehaviour, IDropHandler
{
    public Command assignedCommand;
    private bool isOccupied = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (isOccupied)
        {
            CommandDragHandler droppedCommandHandler = eventData.pointerDrag.GetComponent<CommandDragHandler>();
            if (droppedCommandHandler != null)
            {
                droppedCommandHandler.transform.localPosition = droppedCommandHandler.originalPosition;
            }
            return;
        }

        CommandDragHandler dragHandler = eventData.pointerDrag.GetComponent<CommandDragHandler>();

        if (dragHandler != null)
        {
            assignedCommand = dragHandler.commandData;

            RectTransform commandRectTransform = dragHandler.GetComponent<RectTransform>();
            commandRectTransform.SetParent(transform);
            commandRectTransform.localPosition = Vector3.zero;

            isOccupied = true;
        }
    }

    public void ClearDropZone()
    {
        assignedCommand = null;
        isOccupied = false;
    }
}
