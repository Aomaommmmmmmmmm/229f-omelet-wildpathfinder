using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthTest : MonoBehaviour
{
    public int maxHealth = 100; // Maximum HP
    private int currentHealth; // Current HP

    void Start()
    {
        currentHealth = maxHealth; // Initialize HP
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if HP is depleted
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // Trigger death and load GameOver scene
        }
    }

    void Die()
    {
        // Load GameOver scene
        SceneManager.LoadScene("GameOver");
    }

    // Optional: Getter for current health (useful for UI)
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}