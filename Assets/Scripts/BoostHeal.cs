using UnityEngine;

public class BoostHeal : MonoBehaviour
{
    public float moveSpeed;

    public AudioClip soundEffect;

    private void Update()
    {
        if (!GameOver.instance.gameIsOver)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            PlayerHealth.instance.playerHealth++;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
