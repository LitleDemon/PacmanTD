using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Stats Config")]
    public EnemyStats stats;

    private float currentHealth;
    public bool IsAlive => currentHealth > 0;

    void Start()
    {
        if (stats != null)
        {
            currentHealth = stats.maxHealth;
        }
        else
        {
            Debug.LogError("Не назначен EnemyStats на префабе!");
        }
    }

    public void TakeDamage(float amount)
    {
        if (!IsAlive) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{stats.enemyName} уничтожен!");

        // ВАЖНО: Раскомментируй эту строку, когда Человек Б сделает GameManager
        // if (GameManager.Instance != null) GameManager.Instance.AddPellets(stats.rewardPellets);

        Destroy(gameObject);
    }
}