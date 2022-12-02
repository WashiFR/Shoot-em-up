using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed;

    void Update()
    {
        if(!GameOver.instance.gameIsOver)
        {
            transform.position += new Vector3(0, bulletSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
