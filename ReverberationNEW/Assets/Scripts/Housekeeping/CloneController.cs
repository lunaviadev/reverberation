using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    private Queue<Command> commandQueue = new Queue<Command>();
    private bool isExecuting = false;

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
            // Perform the action set out by the command
            yield return StartCoroutine(PerformCommand(command));
        }
        isExecuting = false;
    }

    private IEnumerator PerformCommand(Command command)
    {
        if (command.action == "Move")
        {
            // Example: Move to target position over time
            Vector2 startPosition = transform.position;
            float duration = 1f;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                transform.position = Vector2.Lerp(startPosition, command.targetPosition, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = command.targetPosition;
        }
    }
}

