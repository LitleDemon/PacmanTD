using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [Header("Tower Stats")]
    public float range = 3f;
    public float fireRate = 1f;
    public float damage = 2f;
    public GameObject projectilePrefab;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        EnemyHealth target = FindFirstEnemy();

        if (target != null)
        {
            GameObject bulletGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile bullet = bulletGO.GetComponent<Projectile>();

            if (bullet != null)
            {
                bullet.Seek(target.transform, damage);
            }

            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private EnemyHealth FindFirstEnemy()
    {
        EnemyHealth[] enemies = FindObjectsByType<EnemyHealth>();
        EnemyHealth bestTarget = null;
        float maxDistanceTravelled = -1f;

        foreach (EnemyHealth enemy in enemies)
        {
            float distanceToTower = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToTower > range) continue;

            EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
            if (movement == null) continue;

            if (movement.DistanceTravelled > maxDistanceTravelled)
            {
                maxDistanceTravelled = movement.DistanceTravelled;
                bestTarget = enemy;
            }
        }

        return bestTarget;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}