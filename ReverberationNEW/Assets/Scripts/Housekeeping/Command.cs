using UnityEngine;

[System.Serializable]
public class Command
{
    public string action; // Action type (e.g., "Move")
    public Vector3 targetPosition; // Target position for movement
}
