using UnityEngine;

[System.Serializable]
public class Command
{
    public string action; // Action type (e.g., "Move")
    public DropBox.MovementCommands movementCommand; // Movement type (e.g., MoveLeft, MoveRight)
    
    public Command(string action, DropBox.MovementCommands movementCommand)
    {
        this.action = action;
        this.movementCommand = movementCommand;
    }
}
