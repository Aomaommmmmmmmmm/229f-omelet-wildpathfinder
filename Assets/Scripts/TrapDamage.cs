using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int damageAmount = 10; // ดาเมจต่อครั้ง
    public float damageCooldown = 1f; // เวลาระหว่างดาเมจ
    private float lastDamageTime;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time > lastDamageTime + damageCooldown)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}
