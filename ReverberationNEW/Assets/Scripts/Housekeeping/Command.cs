using UnityEngine;

[System.Serializable]
public class Command
{
    public string action;
    public DropBox.MovementCommands movementCommand;
    
    public Command(string action, DropBox.MovementCommands movementCommand)
    {
        this.action = action;
        this.movementCommand = movementCommand;
    }
}
