using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public GameObject uiInstance; // UI for this clone
    private bool isPlayerNearby = false;
    private CloneCommandExecutor commandExecutor;

    private void Start()
    {
        commandExecutor = GetComponent<CloneCommandExecutor>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);

        if (distance < 5f && !isPlayerNearby)
        {
            isPlayerNearby = true;
            uiInstance.SetActive(true);
        }
        else if (distance >= 5f && isPlayerNearby)
        {
            isPlayerNearby = false;
            uiInstance.SetActive(false);
        }
    }

    public void SetUpClone()
    {
        commandExecutor = gameObject.AddComponent<CloneCommandExecutor>(); // Attach command executor
    }

    public void ExecuteCloneCommands()
    {
        List<Command> collectedCommands = new List<Command>();

        // Find all drop zones in the clone's UI
        CommandDropHandler[] dropZones = uiInstance.GetComponentsInChildren<CommandDropHandler>();

        foreach (CommandDropHandler dropZone in dropZones)
        {
            collectedCommands.Add(dropZone.assignedCommand); // Add the command to the list
        }

        commandExecutor.LoadCommands(collectedCommands); // Load commands into the executor
        commandExecutor.ExecuteCommands(); // Execute the commands
    }
}
