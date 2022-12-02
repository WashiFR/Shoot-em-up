using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    public GameObject bullet;
    public GameObject spawnBulletPos;
    
    public float delay = 0;
    public float delayBeforeShoot;

    Vector2 movement;

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
    }

    public void Shoot()
    {
        delay = 0;
        Instantiate(bullet, new Vector3(spawnBulletPos.transform.position.x, spawnBulletPos.transform.position.y, 0), Quaternion.identity);
    }
}
