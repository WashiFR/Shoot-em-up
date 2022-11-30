using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;

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
    }
}
