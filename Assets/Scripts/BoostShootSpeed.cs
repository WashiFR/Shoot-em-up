using UnityEngine;

public class BoostShootSpeed : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        if (!GameOver.instance.gameIsOver)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControls.instance.delayBeforeShoot -= 0.05f;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
