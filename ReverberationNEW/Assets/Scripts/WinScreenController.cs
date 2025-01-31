using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    public GameObject winScreenPanel; 
    public Button retryButton;
    public Button quitButton;

    void Start()
    {
        
        winScreenPanel.SetActive(false);

        
        retryButton.onClick.AddListener(Retry);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            ShowWinScreen();
        }
    }
    public void ShowWinScreen()
    {
        winScreenPanel.SetActive(true);
        Time.timeScale = 0; 
    }

   
    public void Retry()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void QuitGame()
    {
        Application.Quit(); 

    }
}

