using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public bool gameIsOver = false;

    public static GameOver instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de GameOver dans la scène");
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
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(PlayerHealth.instance.deathExplosion.main.duration);
        Time.timeScale = 0;
    }
}
