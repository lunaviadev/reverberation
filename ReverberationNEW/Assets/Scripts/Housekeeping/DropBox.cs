using UnityEngine;

public class DropBox : MonoBehaviour
{
    private Command assignedCommand;

    public void AssignCommand(Command command)
    {
        assignedCommand = command;
    }

    public Command GetAssignedCommand()
    {
        return assignedCommand;
    }
}
