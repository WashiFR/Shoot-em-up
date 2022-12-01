using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int playerScore;
    public int playerHighScore;

    public Text playerScoreText;

    public static PlayerScore instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerScore dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        playerScore = 0;
    }

    public void AddPoints(int points)
    {
        playerScore += points;
        playerScoreText.text = playerScore.ToString();
    }
}
