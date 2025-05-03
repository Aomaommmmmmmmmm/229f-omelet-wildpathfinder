using UnityEngine;

public class SpikeBallDamage : MonoBehaviour
{
    public int damageAmount = 15; // ดาเมจต่อครั้ง
    public float damageCooldown = 1f; // เวลาระหว่างดาเมจ
    private float lastDamageTime;

    private void OnTriggerEnter2D(Collider2D other)
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
