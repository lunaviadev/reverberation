using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public string action;
    public Vector2 targetPosition;

    public Command(string action, Vector2 targetPosition)
    {
        this.action = action;
        this.targetPosition = targetPosition;
    }
}

