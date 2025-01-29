using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{
    public enum MovementCommands
    {
        MoveUp,
        MoveRight,
        MoveLeft,
        MoveUpRight,
        MoveUpLeft,
        Wait,
    }

    private List<MovementCommands> commandQueue = new List<MovementCommands>();

    public void AddCommand(MovementCommands command)
    {
        commandQueue.Add(command);
    }

    public List<MovementCommands> GetCommands()
    {
        return commandQueue;
    }
}
