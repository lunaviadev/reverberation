using UnityEngine;

public class ToggleUIWithDistance : MonoBehaviour
{
    [SerializeField] private GameObject commandsParent;
    [SerializeField] private GameObject dropZonesParent;
    [SerializeField] private Transform player;
    [SerializeField] private float maxDistance = 5f;

    private Vector3 savedPosition;
    private bool isUIVisible = false;

    void Awake()
    {
        isUIVisible = false;
        if (commandsParent != null)
            commandsParent.SetActive(false);
        if (dropZonesParent != null)
            dropZonesParent.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isUIVisible)
            {
                savedPosition = player.position;
                ToggleUI(true);
            }
            else
            {
                ToggleUI(false);
            }
        }

        if (isUIVisible)
        {
            if (Vector3.Distance(player.position, savedPosition) > maxDistance)
            {
                ToggleUI(false);
            }
        }
        else
        {
            if (Vector3.Distance(player.position, savedPosition) <= maxDistance)
            {
                ToggleUI(true);
            }
        }
    }

    private void ToggleUI(bool isVisible)
    {
        isUIVisible = isVisible;
        if (commandsParent != null)
            commandsParent.SetActive(isVisible);
        if (dropZonesParent != null)
            dropZonesParent.SetActive(isVisible);
    }
}
