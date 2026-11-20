using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public PathConfig testPath;

    void Start()
    {
        // Спавним врага и сразу говорим ему идти по пути
        GameObject newEnemy = Instantiate(enemyPrefab);
        EnemyMovement movement = newEnemy.GetComponent<EnemyMovement>();

        if (movement != null)
        {
            movement.Initialize(testPath);
        }
    }
}