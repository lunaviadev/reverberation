using UnityEngine;
using UnityEngine.EventSystems;

public class CommandDropHandler : MonoBehaviour, IDropHandler
{
    public Command commandData; // The command data to be associated with this drop zone

    public void OnDrop(PointerEventData eventData)
    {
        CommandDragHandler dragHandler = eventData.pointerDrag.GetComponent<CommandDragHandler>(); // Get the dragged command
        if (dragHandler != null)
        {
            Command droppedCommand = dragHandler.commandData; // Get the command data from the dragged object

            if (droppedCommand != null)
            {
                // Move the dragged command to the drop zone and set its parent to the drop zone
                dragHandler.transform.SetParent(transform);
                dragHandler.transform.position = transform.position;  // Position the command in the center of the drop zone

                // Optionally: Save or perform some other action with the dropped command
                commandData = droppedCommand;
            }
        }
    }
}
