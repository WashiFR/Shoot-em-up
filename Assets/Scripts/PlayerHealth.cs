using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;

    public Image[] hearths;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < playerHealth)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHearth;
            }

            if (i < playerMaxHealth)
            {
                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }

        if (playerHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage()
    {
        playerHealth--;
    }

    public void Death()
    {
        Destroy(gameObject);

        if (PlayerScore.instance.playerScore > PlayerScore.instance.playerHighScore)
        {
            PlayerScore.instance.playerHighScore = PlayerScore.instance.playerScore;
        }
    }
}
