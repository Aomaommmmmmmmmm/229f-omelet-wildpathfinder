using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public int damage = 20; // ดาเมจที่ลูกธนูทำได้

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // ทำลายลูกธนูเมื่อชนผู้เล่น
        }
        
    }
}