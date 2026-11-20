using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "TD/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float speed;
    public int rewardPellets; // Сколько пеллет даст за убийство (для Человека Б)
}