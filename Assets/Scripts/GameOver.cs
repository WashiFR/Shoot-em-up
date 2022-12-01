using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameIsOver = false;

    public static GameOver instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de GameOver dans la sc�ne");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if(PlayerHealth.instance.playerHealth <= 0)
        {
            GameIsOver();
        }
    }

    public void GameIsOver()
    {
        gameIsOver = true;
        Time.timeScale = 0;
    }
}
