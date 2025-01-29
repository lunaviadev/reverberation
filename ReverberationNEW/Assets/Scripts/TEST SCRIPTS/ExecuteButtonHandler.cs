using UnityEngine;

public class ExecuteButtonHandler : MonoBehaviour
{
    public CloneController cloneController;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExecuteCommands();
        }
    }

    public void ExecuteCommands()
    {
        if (cloneController != null)
        {
            cloneController.ExecuteCloneCommands();
        }
    }
}
