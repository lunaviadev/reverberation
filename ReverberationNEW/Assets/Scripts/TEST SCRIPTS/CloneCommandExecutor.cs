using System.Collections.Generic;
using UnityEngine;

public class CloneCommandExecutor : MonoBehaviour
{
    private List<Command> commands = new List<Command>();

    // Load the commands into the executor
    public void LoadCommands(List<Command> newCommands)
    {
        commands = newCommands;
    }

    // Execute all the commands
    public void ExecuteCommands()
    {
        foreach (Command command in commands)
        {
            switch (command.movementCommand)
            {
                case DropBox.MovementCommands.MoveLeft:
                    MoveLeft();
                    break;
                case DropBox.MovementCommands.MoveRight:
                    MoveRight();
                    break;
                case DropBox.MovementCommands.MoveUp:
                    MoveUp();
                    break;
                case DropBox.MovementCommands.MoveUpLeft:
                    MoveLeftAndUp();
                    break;
                case DropBox.MovementCommands.MoveUpRight:
                    MoveRightAndUp();
                    break;
                default:
                    break;
            }
        }
    }

    // Movement logic for each type of command
    private void MoveLeft() { transform.Translate(Vector3.left); }
    private void MoveRight() { transform.Translate(Vector3.right); }
    private void MoveUp() { transform.Translate(Vector3.up); }
    private void MoveLeftAndUp() { transform.Translate(Vector3.left + Vector3.up); }
    private void MoveRightAndUp() { transform.Translate(Vector3.right + Vector3.up); }
}
