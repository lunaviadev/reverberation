using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static DragHandler;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition; // Reset position if not dropped on a valid target
        //If the command is dropped into a command square for the clone, add logic here
    }
}



