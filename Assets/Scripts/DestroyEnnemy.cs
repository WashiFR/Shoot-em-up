using UnityEngine;

public class DestroyEnnemy : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
