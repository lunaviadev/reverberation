using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public GameObject clonePrefab;
    public GameObject uiPrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateClone();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExecuteCloneCommands();
        }
    }

    private void CreateClone()
    {

    GameObject clone = Instantiate(clonePrefab, transform.position, Quaternion.identity);

    GameObject cloneUI = Instantiate(uiPrefab);
    CloneController cloneController = clone.GetComponent<CloneController>();
    cloneController.uiInstance = cloneUI;

    cloneUI.SetActive(false);

    cloneController.SetUpClone();
    }

    private void ExecuteCloneCommands()
    {
        foreach (var clone in FindObjectsOfType<CloneController>())
        {
            clone.ExecuteCloneCommands();
        }
    }
}
