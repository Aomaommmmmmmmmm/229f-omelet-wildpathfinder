using UnityEngine;

public class ArrowBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject); // ทำลายวัตถุที่โดน
            Destroy(gameObject);       // ทำลายตัวกระสุนด้วย
        }
    }
}