using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject clonePrefab; // The clone prefab
    public Transform player; // Reference to the player Transform
    public GameObject uiPanel; // The UI Panel (the draggable UI)
    public int poolSize = 10; // Pool size
    public float maxDistance = 5f; // Maximum distance for proximity detection
    public float spawnOffset = 0.5f; // Slight offset to spawn clone behind player

    private List<GameObject> clonePool = new List<GameObject>();
    private Dictionary<GameObject, Vector3> clonePositions = new Dictionary<GameObject, Vector3>();

    private void Awake()
    {
        if (clonePrefab == null)
        {
            Debug.LogError("Clone Prefab is not assigned.");
        }

        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned.");
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(clonePrefab);
            clone.SetActive(false);
            clonePool.Add(clone);
        }

        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // Initially hide the UI
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaceCloneAndSavePosition();
        }

        CheckCloneInteraction();
        ToggleUI();
    }

    private void PlaceCloneAndSavePosition()
    {
        GameObject clone = GetClone();
        if (clone != null && player != null)
        {
            // Calculate the position directly at the player's position
            Vector3 spawnPosition = player.position + player.forward * spawnOffset;

            // Initialize clone's position
            CloneController cloneController = clone.GetComponent<CloneController>();
            cloneController.Initialize(spawnPosition);

            // Set the clone's Rigidbody to kinematic to prevent it from being pushed
            Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();
            if (cloneRigidbody != null)
            {
                cloneRigidbody.isKinematic = true;
            }

            // Set the clone's position in the scene
            clone.transform.position = spawnPosition;

            // Save the clone's position
            clonePositions[clone] = spawnPosition;
            clone.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Clone or player not properly initialized.");
        }
    }

    private GameObject GetClone()
    {
        foreach (var clone in clonePool)
        {
            if (!clone.activeInHierarchy)
            {
                return clone;
            }
        }
        return null; // No available clone in the pool
    }

    private void CheckCloneInteraction()
    {
        bool playerInProximity = false;

        foreach (var cloneEntry in clonePositions)
        {
            GameObject clone = cloneEntry.Key;
            CloneController cloneController = clone.GetComponent<CloneController>();

            if (Vector3.Distance(player.position, clone.transform.position) <= maxDistance)
            {
                playerInProximity = true;
            }
        }

        // If no clone is in proximity, toggle off the UI
        if (!playerInProximity && uiPanel.activeSelf)
        {
            uiPanel.SetActive(false);
        }
    }
    private void ToggleUI()
    {
        bool playerInProximity = false;

        // Check if any clone is within proximity
        foreach (var cloneEntry in clonePositions)
        {
            GameObject clone = cloneEntry.Key;
            if (Vector3.Distance(player.position, clone.transform.position) <= maxDistance)
            {
                playerInProximity = true;
            }
        }

        // Toggle the UI visibility based on proximity to clones
        if (playerInProximity && !uiPanel.activeSelf)
        {
            uiPanel.SetActive(true);
        }
        else if (!playerInProximity && uiPanel.activeSelf)
        {
            uiPanel.SetActive(false);
        }
    }

    public void ReturnClone(GameObject clone)
    {
        clone.SetActive(false);
    }
}
