using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    [SerializeField] Transform player;                   // ตำแหน่งของผู้เล่น
    [SerializeField] Rigidbody2D arrowPrefab;            // กระสุนลูกธนู
    [SerializeField] Transform shootPoint;               // จุดที่ลูกธนูออก
    [SerializeField] float detectionRange = 5f;          // ระยะยิง
    [SerializeField] float shootCooldown = 2f;           // เวลาระหว่างยิง
    [SerializeField] float timeToTarget = 1f;            // ใช้ในการคำนวณวิถี
    [SerializeField] float bulletLifetime = 5f;          // อายุของลูกธนู

    private float lastShootTime;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // หันไปทางผู้เล่น
            Vector2 direction = (player.position - transform.position).normalized;
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);

            // ยิงถ้า cooldown ครบ
            if (Time.time > lastShootTime + shootCooldown)
            {
                ShootProjectile(player.position);
                lastShootTime = Time.time;
            }
        }
    }

    void ShootProjectile(Vector2 targetPosition)
    {
        // คำนวณความเร็ว
        Vector2 velocity = CalculateProjectileVelocity(shootPoint.position, targetPosition, timeToTarget);

        // สร้างกระสุน
        Rigidbody2D arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
        arrow.linearVelocity = velocity;

        Destroy(arrow.gameObject, bulletLifetime);
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float gravity = Physics2D.gravity.y;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time - 0.5f * gravity * time;

        return new Vector2(velocityX, velocityY);
    }
}