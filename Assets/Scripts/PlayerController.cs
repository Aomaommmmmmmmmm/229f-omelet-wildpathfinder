using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HealthBarSystem healthBar; // อ้างอิงถึง HealthBarSystem
    [SerializeField] private float damagePerHit = 10f; // ความเสียหายต่อครั้ง

    void Update()
    {
        // ทดสอบการรับความเสียหายเมื่อกด Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBar.TakeDamage(damagePerHit);
        }
        // ทดสอบการรักษาเมื่อกด H
        if (Input.GetKeyDown(KeyCode.H))
        {
            healthBar.Heal(damagePerHit);
        }
    }

    // เมื่อตัวละครชนกับ Hook, Trap, หรือ Enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("Hook") || 
            collision.gameObject.CompareTag("Trap"))
        {
            healthBar.TakeDamage(damagePerHit);
        }
    }
}