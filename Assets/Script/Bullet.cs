using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Handle collision with enemy
            collision.GetComponent<EnemyHealth>().Die();
            Destroy(gameObject); // Destroy the bullet GameObject
        }
    }
}
