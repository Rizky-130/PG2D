using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 15;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        // Handle enemy death (e.g., reload scene, show game over screen)
        Debug.Log("Enemy has died.");
        Destroy(gameObject); // Destroy the enemy GameObject
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // Assuming the player has a PlayerHealth script attached
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Deal 10 damage to the player
                Destroy(gameObject); // Destroy the enemy after dealing damage
                Debug.Log("Player has taken damage from enemy." + playerHealth.health + " health remaining.");
           }
        }
    }
}
