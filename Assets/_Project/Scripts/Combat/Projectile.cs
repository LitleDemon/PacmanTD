using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private float damage;
    private Transform target;

    public void Seek(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

    void Update()
    {
        // Если цель внезапно умерла и GameObject уничтожился
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Проверяем, что враг еще жив, прежде чем наносить урон
        EnemyHealth enemy = target.GetComponent<EnemyHealth>();
        if (enemy != null && enemy.IsAlive)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}