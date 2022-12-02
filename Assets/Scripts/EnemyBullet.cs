using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;

    void Update()
    {
        if (!GameOver.instance.gameIsOver)
        {
            transform.position -= new Vector3(0, bulletSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerHealth.instance.TakeDamage();
        }
    }
}
