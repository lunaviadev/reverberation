using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;  

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    public Button restartButton;    
    public Button quitButton;       

    private bool isPaused = false;  

    void Start()
    {
        
        pauseMenuUI.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;  
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);  
        Time.timeScale = 1f;  
    }


    public void RestartLevel()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }
}


