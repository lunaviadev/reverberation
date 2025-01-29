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
    Debug.Log("Setting up clone...");

    if (commandExecutor == null)
    {
        commandExecutor = gameObject.AddComponent<CloneCommandExecutor>(); // Attach command executor
        Debug.Log("Command executor initialized.");
    }
    else
    {
        Debug.Log("Command executor already exists.");
    }
}


    public void ExecuteCloneCommands()
{
    if (commandExecutor == null)
    {
        Debug.LogError("Command Executor not initialized.");
        return;
    }

    List<Command> collectedCommands = new List<Command>();

    if (uiInstance == null)
    {
        Debug.LogError("UI instance is not assigned.");
        return;
    }

    CommandDropHandler[] dropZones = uiInstance.GetComponentsInChildren<CommandDropHandler>();

    foreach (CommandDropHandler dropZone in dropZones)
    {
        if (dropZone.assignedCommand != null)
        {
            collectedCommands.Add(dropZone.assignedCommand);
        }
    }

    commandExecutor.LoadCommands(collectedCommands);
    commandExecutor.ExecuteCommands();
}
}
