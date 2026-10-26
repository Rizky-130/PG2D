using UnityEngine;

public class Bullet : WasteItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Handle collision with enemy
            collision.GetComponent<EnemyHealth>().Die();
            Destroy(gameObject); // Destroy the bullet GameObject
        }
        if (collision.CompareTag("Sampah"))
        {
            Destroy(gameObject);
        }
    }
}
