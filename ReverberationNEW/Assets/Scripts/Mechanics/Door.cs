using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 initialPosition;
    public float openHeight = 2f; // How much the door moves up when opening
    public float openSpeed = 2f; // Speed of opening and closing

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(initialPosition + Vector3.up * openHeight));
    }

    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(initialPosition));
    }

    private System.Collections.IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, openSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
}

