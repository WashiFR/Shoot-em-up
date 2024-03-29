using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    public GameObject bullet;
    public GameObject spawnBulletPos;
    
    public float delay = 0;
    public float delayBeforeShoot;

    public AudioClip soundEffect;

    Vector2 movement;

    public static PlayerControls instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerControls dans la sc�ne");
            return;
        }

        instance = this;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(Input.GetKey(KeyCode.Space) && delay > delayBeforeShoot && !GameOver.instance.gameIsOver)
        {
            Shoot();
        }

        delay += Time.deltaTime;

        if(delayBeforeShoot < 0.1)
        {
            delayBeforeShoot = 0.1f;
        }
    }

    public void Shoot()
    {
        delay = 0;
        Instantiate(bullet, new Vector3(spawnBulletPos.transform.position.x, spawnBulletPos.transform.position.y, 0), Quaternion.identity);
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
    }
}
