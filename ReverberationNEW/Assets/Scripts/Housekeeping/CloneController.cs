using UnityEngine;

public class CloneController : MonoBehaviour
{
    public GameObject uiInstance; // UI prefab for this clone
    private bool isPlayerNearby = false;

    private void Update()
    {
        // Check proximity to player and toggle UI visibility
        float distance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        
        if (distance < 5f && !isPlayerNearby)
        {
            isPlayerNearby = true;
            uiInstance.SetActive(true); // Show UI when close
        }
        else if (distance >= 5f && isPlayerNearby)
        {
            isPlayerNearby = false;
            uiInstance.SetActive(false); // Hide UI when far
        }
    }

    // Set up any necessary components for the clone
    public void SetUpClone()
    {
        // Here we can add any clone-specific setup (e.g., initializing commands)
    }
}
