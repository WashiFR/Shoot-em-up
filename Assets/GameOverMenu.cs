using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    public void RetryButton()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
        GameOver.instance.gameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        PauseMenu.instance.Resume();
        StartGame.instance.gameIsStarted = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
