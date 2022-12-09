using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool gameIsPaused = false;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PauseMenu dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            gameIsPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        gameIsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        Resume();
        StartGame.instance.gameIsStarted = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
