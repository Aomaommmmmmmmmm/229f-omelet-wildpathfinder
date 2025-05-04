using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public GameObject gameOverPanel; // ลาก UI Panel มาใส่ตรงนี้

    private void Start()
    {
        currentHealth = maxHealth;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // ซ่อนไว้ก่อน
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage: " + amount + " | Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // แสดงหน้าต่าง Game Over
        }

        Time.timeScale = 0f; // หยุดเกม
    }
}