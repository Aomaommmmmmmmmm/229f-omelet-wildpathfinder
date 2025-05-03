using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    private int currentHealth;
    private SpriteRenderer spriteRenderer; // อ้างอิง SpriteRenderer
    private Color originalColor; // สีเริ่มต้นของ Sprite
    [SerializeField] private float flashDuration = 0.2f; // ระยะเวลาการกระพริบต่อครั้ง
    [SerializeField] private int flashCount = 3; // จำนวนครั้งที่กระพริบ
    [SerializeField] private Color flashColor = Color.blue; // สีสำหรับกระพริบ (เปลี่ยนเป็นน้ำเงิน)

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // ตรวจสอบว่า SpriteRenderer มีอยู่
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on " + gameObject.name + ". Trying to find in children.");
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer not found in children either!");
            }
        }
        
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            Debug.Log("SpriteRenderer found. Original color: " + originalColor + ", Flash color: " + flashColor);
        }
    }

    // ตรวจจับการชนกับหนาม
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger detected with: " + col.gameObject.name);
        if (col.CompareTag("Trap"))
        {
            Debug.Log("Collided with Trap (thorn). Triggering TakeDamage.");
            TakeDamage(20); // ลด HP เมื่อชนหนาม
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage: " + amount + " | Current HP: " + currentHealth);

        // เริ่มการกระพริบถ้ามี SpriteRenderer
        if (spriteRenderer != null)
        {
            Debug.Log("Starting FlashColor Coroutine");
            StartCoroutine(FlashColor());
        }
        else
        {
            Debug.LogWarning("Cannot flash because SpriteRenderer is null");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashColor()
    {
        for (int i = 0; i < flashCount; i++)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = flashColor; // เปลี่ยนเป็นสีที่กำหนด (น้ำเงิน)
                Debug.Log("Flashing color: " + flashColor);
                yield return new WaitForSeconds(flashDuration);
                spriteRenderer.color = originalColor; // กลับไปสีเดิม
                Debug.Log("Restoring original color: " + originalColor);
                yield return new WaitForSeconds(flashDuration);
            }
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // ทำลายตัวละครหรือโหลด scene ได้ตามต้องการ
    }
}