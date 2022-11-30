using UnityEngine;

public class EnnemyBullet : MonoBehaviour
{
    public float bulletSpeed;

    void Update()
    {
        transform.position -= new Vector3(0, bulletSpeed * Time.deltaTime);
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
