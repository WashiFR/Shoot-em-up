using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;

    public Image[] hearths;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    public bool isInvincible = false;
    public SpriteRenderer graphics;

    public ParticleSystem deathExplosion;

    public GameObject gameOverMenu;

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

        if(playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }

    public void TakeDamage()
    {
        if(!isInvincible)
        {
            playerHealth--;
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());
        }
    }

    public void Death()
    {
        var death = Instantiate(deathExplosion, transform.position, transform.rotation);
        death.Play();
        Destroy(gameObject);
        Destroy(death.gameObject, death.main.duration);

        gameOverMenu.SetActive(true);

        if (PlayerScore.instance.playerScore > PlayerScore.instance.playerHighScore)
        {
            PlayerScore.instance.playerHighScore = PlayerScore.instance.playerScore;
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(graphics.color.r, graphics.color.g, graphics.color.b, 0f);
            yield return new WaitForSeconds(0.1f);
            graphics.color = new Color(graphics.color.r, graphics.color.g, graphics.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator InvincibilityDelay()
    {
        yield return new WaitForSeconds(3f);
        isInvincible = false;
    }
}
