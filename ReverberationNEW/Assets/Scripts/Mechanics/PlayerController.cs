using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public GameObject clonePrefab; // Reference to the clone prefab
    public GameObject uiPrefab; // Reference to the UI prefab for commands

    private void Awake()
    {
        Instance = this; // Singleton pattern
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateClone();
        }
    }

    private void CreateClone()
    {
        // Create clone at player position
        GameObject clone = Instantiate(clonePrefab, transform.position, Quaternion.identity);

        // Set up clone-specific UI
        GameObject cloneUI = Instantiate(uiPrefab);
        CloneController cloneController = clone.GetComponent<CloneController>();
        cloneController.uiInstance = cloneUI;

        // Hide the UI at the start
        cloneUI.SetActive(false);

        // Associate clone with its UI
        cloneController.SetUpClone();
    }
}
