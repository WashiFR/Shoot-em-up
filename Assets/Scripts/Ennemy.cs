using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    public GameObject bullet;
    public GameObject spawnBulletPos;

    public int delay = 0;
    public int minDelay;
    public int maxDelay;
    public int delayBeforeShoot;

    private void Start()
    {
        maxDelay = Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        transform.position -= new Vector3(0, moveSpeed * Time.deltaTime);

        if (delay > maxDelay)
        {
            Shoot();
        }

        delay++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Death();
            PlayerHealth.instance.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Death();
        }
    }

    public void Shoot()
    {
        delay = 0;
        Instantiate(bullet, new Vector3(spawnBulletPos.transform.position.x, spawnBulletPos.transform.position.y, 0), Quaternion.identity);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
