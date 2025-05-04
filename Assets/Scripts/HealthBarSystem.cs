using UnityEngine;
using UnityEngine.UI;
using TMPro; // เพิ่ม namespace สำหรับ TextMeshPro

public class HealthBarSystem : MonoBehaviour
{
    [SerializeField] private Image healthBarFill; // UI Image สำหรับแถบ HP
    [SerializeField] private TMP_Text healthText; // เปลี่ยนจาก Text เป็น TMP_Text
    [SerializeField] private float maxHealth = 100f; // HP สูงสุด
    private float currentHealth; // HP ปัจจุบัน

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่า HP เริ่มต้น
        UpdateHealthBar();
    }

    // ฟังก์ชันลด HP
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // จำกัดค่า HP ไม่ให้เกิน 0 หรือ max
        UpdateHealthBar();
    }

    // ฟังก์ชันเพิ่ม HP
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // อัพเดทแถบ HP และตัวเลข
    private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth; // อัพเดทความยาวแถบ
        if (healthText != null) // ตรวจสอบว่า healthText ไม่เป็น null
        {
            healthText.text = $"{currentHealth}/{maxHealth}"; // อัพเดทตัวเลข
        }
    }
}