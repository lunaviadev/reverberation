using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    private Queue<Command> commandQueue = new Queue<Command>();
    private bool isExecuting = false;
    private Vector3 savedPosition; // Position where the clone was placed
    private bool isActive = false; // Tracks if the clone is active for interaction
    public void Initialize(Vector3 position)
    {
        savedPosition = position;
        transform.position = position;
        SetActiveState(false); // Start inactive
    }
    public void AddCommand(Command command)
    {
        commandQueue.Enqueue(command);
    }
    public void ExecuteCommands()
    {
        if (!isExecuting && commandQueue.Count > 0)
        {
            StartCoroutine(ExecuteCommandQueue());
        }
    }
    private IEnumerator ExecuteCommandQueue()
    {
        isExecuting = true;
        while (commandQueue.Count > 0)
        {
            Command command = commandQueue.Dequeue();
            yield return StartCoroutine(PerformCommand(command));
        }
        isExecuting = false;
    }
    private IEnumerator PerformCommand(Command command)
    {
        if (command.action == "Move")
        {
            Vector3 startPosition = transform.position;
            float duration = 1f;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                transform.position = Vector3.Lerp(startPosition, command.targetPosition, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = command.targetPosition;
        }
    }
    public bool CheckProximity(Vector3 playerPosition, float maxDistance)
    {
        float distance = Vector3.Distance(playerPosition, savedPosition);
        return distance <= maxDistance;
    }

    public void SetActiveState(bool state)
    {
        isActive = state;
        // Add any visual or functional changes when the state changes
        gameObject.SetActive(state);
    }
    public bool GetActiveState()
    {
        return isActive;
    }
    public Vector3 GetSavedPosition()
    {
        return savedPosition;
    }
}
