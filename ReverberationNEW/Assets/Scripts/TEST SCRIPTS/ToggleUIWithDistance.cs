using System.Collections.Generic;
using UnityEngine;

public class ToggleUIWithDistance : MonoBehaviour
{
    [SerializeField] private GameObject commandsPrefab;
    [SerializeField] private GameObject dropZonesPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float maxDistance = 5f;

    private Dictionary<Transform, UIState> cloneUIStates = new Dictionary<Transform, UIState>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Transform nearestClone = GetNearestClone();
            if (nearestClone != null)
            {
                if (!cloneUIStates.ContainsKey(nearestClone))
                {
                    SavePositionForClone(nearestClone);
                }

                var uiState = cloneUIStates[nearestClone];
                if (!uiState.IsUIVisible)
                {
                    ToggleUI(uiState, true);
                }
                else
                {
                    ToggleUI(uiState, false);
                }
            }
        }
        foreach (var kvp in cloneUIStates)
        {
            var clone = kvp.Key;
            var uiState = kvp.Value;

            if (uiState.IsUIVisible && Vector3.Distance(player.position, uiState.SavedPosition) > maxDistance)
            {
                ToggleUI(uiState, false);
            }
            else if (!uiState.IsUIVisible && Vector3.Distance(player.position, uiState.SavedPosition) <= maxDistance)
            {
                ToggleUI(uiState, true);
            }
        }
    }
    private Transform GetNearestClone()
    {
        float closestDistance = float.MaxValue;
        Transform nearestClone = null;

        foreach (var clone in cloneUIStates.Keys)
        {
            float distance = Vector3.Distance(player.position, clone.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestClone = clone;
            }
        }

        return nearestClone;
    }
    private void SavePositionForClone(Transform clone)
    {
        Vector3 savedPosition = player.position;

        GameObject commandsParent = Instantiate(commandsPrefab);
        GameObject dropZonesParent = Instantiate(dropZonesPrefab);

        commandsParent.SetActive(false);
        dropZonesParent.SetActive(false);

        cloneUIStates.Add(clone, new UIState
        {
            SavedPosition = savedPosition,
            CommandsParent = commandsParent,
            DropZonesParent = dropZonesParent,
            IsUIVisible = false
        });
    }
    private void ToggleUI(UIState uiState, bool isVisible)
    {
        uiState.IsUIVisible = isVisible;
        uiState.CommandsParent.SetActive(isVisible);
        uiState.DropZonesParent.SetActive(isVisible);
    }
}
public class UIState
{
    public Vector3 SavedPosition;
    public GameObject CommandsParent;
    public GameObject DropZonesParent;
    public bool IsUIVisible;
}
