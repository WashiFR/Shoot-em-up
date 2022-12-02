using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public Rigidbody2D rb;
    public bool isDead = false;

    public ParticleSystem explosion;

    public GameObject bullet;
    public GameObject spawnBulletPos;

    public int points;

    public float delay = 0;
    public float minDelay;
    public float maxDelay;
    public float delayBeforeShoot;

    private void Start()
    {
        delayBeforeShoot = Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        if(!isDead && !GameOver.instance.gameIsOver)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime);
        }

        if(health <= 0)
        {
            Death();
        }

        if (delay > delayBeforeShoot && !GameOver.instance.gameIsOver && !isDead)
        {
            Shoot();
        }

        delay += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage();
            PlayerHealth.instance.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage();
        }
    }

    public void Shoot()
    {
        delay = 0;
        Instantiate(bullet, new Vector3(spawnBulletPos.transform.position.x, spawnBulletPos.transform.position.y, 0), Quaternion.identity);
        delayBeforeShoot = Random.Range(minDelay, maxDelay);
    }

    public void TakeDamage()
    {
        health--;
    }

    public void Death()
    {
        isDead = true;
        var death = Instantiate(explosion, transform.position, transform.rotation);
        death.Play();

        Destroy(gameObject);
        Destroy(death.gameObject, death.main.duration);

        PlayerScore.instance.AddPoints(points);
    }
}
