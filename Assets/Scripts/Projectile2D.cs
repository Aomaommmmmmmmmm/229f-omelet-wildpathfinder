using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target; // target sprite
    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] float timeToTarget = 1f;
    [SerializeField] float bulletLifetime = 3f; // เวลาก่อนกระสุนหาย

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // shoot raycast to detect mouse clicked position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            // get click point
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                // show target at click point
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("hit " + hit.collider.name);

                // calculate projectile velocity
                Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, timeToTarget);

                // instantiate bullet
                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                shootBullet.linearVelocity = projectileVelocity;

                // destroy bullet after a few seconds
                Destroy(shootBullet.gameObject, bulletLifetime);
            }
        }
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