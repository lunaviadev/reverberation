using UnityEngine;
using UnityEngine.EventSystems;

public class CommandDropHandler : MonoBehaviour, IDropHandler
{
    public int commandID; //clone ID so that each clone can have its own commands and not clash with eachother

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedCommand = eventData.pointerDrag;
        if (droppedCommand != null)
        {
            
            droppedCommand.transform.SetParent(transform);
            droppedCommand.transform.position = transform.position;

            
            Debug.Log($"Command '{droppedCommand.name}' assigned to Clone ID {commandID}");
        }
    }
}
