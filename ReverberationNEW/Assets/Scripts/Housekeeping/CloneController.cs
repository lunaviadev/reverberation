using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public GameObject uiInstance;
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

        if (commandExecutor == null)
        {
            commandExecutor = gameObject.AddComponent<CloneCommandExecutor>();
        }
    }

    public void ExecuteCloneCommands()
    {

        List<Command> collectedCommands = new List<Command>();

        CommandDropHandler[] dropZones = uiInstance.GetComponentsInChildren<CommandDropHandler>();

        foreach (CommandDropHandler dropZone in dropZones)
        {
            if (dropZone.assignedCommand != null)
            {
                collectedCommands.Add(dropZone.assignedCommand);
            }
            else
            {
                dropZone.assignedCommand = null;
            }
        }

        if (collectedCommands.Count == 0)
        {
            return;
        }

        commandExecutor.LoadCommands(collectedCommands);
        commandExecutor.ExecuteCommands();
    }
}
