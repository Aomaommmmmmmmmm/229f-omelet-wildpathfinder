using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI healthText;     // แสดง HP เป็นตัวหนังสือ (ถ้ามี)
    public Image healthBar;                // แถบเลือดแบบ Image

    private void Start()
    {
        currentHealth = maxHealth;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // กันค่าติดลบ

        Debug.Log("Player took damage: " + amount + " | Current HP: " + currentHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "HP: " + currentHealth + " / " + maxHealth;

        if (healthBar != null)
            healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        Debug.Log("Player Died!");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}