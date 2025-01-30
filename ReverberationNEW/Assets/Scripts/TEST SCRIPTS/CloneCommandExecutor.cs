using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCommandExecutor : MonoBehaviour
{
    AudioManager audioManager;
    private UIAudio UIAudio;
    private List<Command> commands = new List<Command>();
    private CloneController cloneController;

    private void Start()
    {
        UIAudio = GetComponent<UIAudio>();
        cloneController = GetComponent<CloneController>();
    }

    public void LoadCommands(List<Command> newCommands)
    {
        commands = newCommands;
    }

    public void ExecuteCommands()
    {
        StartCoroutine(ExecuteCommandsWithDelay());
    }

    private IEnumerator ExecuteCommandsWithDelay()
    {
        foreach (Command command in commands)
        {
            switch (command.movementCommand)
            {
                case DropBox.MovementCommands.MoveLeft:
                    MoveLeft();
                    
                    break;
                case DropBox.MovementCommands.MoveRight:
                    MoveRight();

                    break;
                case DropBox.MovementCommands.MoveUp:
                    MoveUp();

                    break;
                case DropBox.MovementCommands.MoveUpLeft:
                    MoveLeftAndUp();

                    break;
                case DropBox.MovementCommands.MoveUpRight:
                    MoveRightAndUp();

                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        cloneController.ReturnToPool();
    }

    private void MoveLeft() 
    {
        UIAudio.PlayClip(0, false); 
        transform.Translate(Vector3.left); 
    }
    private void MoveRight() 
    {
        UIAudio.PlayClip(1, false); 
        transform.Translate(Vector3.right); }
    private void MoveUp() 
    {
        UIAudio.PlayClip(2, false);
        transform.Translate(Vector3.up); 
    }
    private void MoveLeftAndUp() 
    {
        UIAudio.PlayClip(3, false);
        transform.Translate(Vector3.left + Vector3.up); 
    }
    private void MoveRightAndUp() 
    {
        UIAudio.PlayClip(4, false);
        transform.Translate(Vector3.right + Vector3.up); 
    }

 
}
