using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    public Transform player;                  // ตำแหน่งของผู้เล่น
    public Rigidbody2D arrowPrefab;           // กระสุนลูกธนู
    public Transform shootPoint;              // จุดที่ลูกธนูออก
    public float detectionRange = 5f;         // ระยะยิง
    public float shootCooldown = 2f;          // เวลาระหว่างยิง
    private float lastShootTime;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // หันไปทางผู้เล่น
            Vector2 direction = (player.position - transform.position).normalized;
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1); // กลับข้างถ้าผู้เล่นอยู่ซ้าย

            // ยิงถ้าระยะเวลา cooldown ครบ
            if (Time.time > lastShootTime + shootCooldown)
            {
                Shoot(direction);
                lastShootTime = Time.time;
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        Rigidbody2D arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
        arrow.linearVelocity = direction * 5f; // ปรับความเร็วตามต้องการ

        // ทำลายลูกธนูอัตโนมัติ
        Destroy(arrow.gameObject, 5f);
    }
}