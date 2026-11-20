using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Level Settings")]
    public LevelConfig currentLevel;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    public void StartNextWave()
    {
        if (isSpawning) return;
        if (currentWaveIndex >= currentLevel.waves.Count)
        {
            GameEvents.LevelCompleted();
            return;
        }

        StartCoroutine(SpawnWaveRoutine(currentLevel.waves[currentWaveIndex]));
        currentWaveIndex++;
    }

    private IEnumerator SpawnWaveRoutine(Wave wave)
    {
        isSpawning = true;

        foreach (SpawnGroup group in wave.spawnGroups)
        {
            for (int i = 0; i < group.count; i++)
            {
                SpawnEnemy(group.enemyPrefab, wave.targetPathID);
                yield return new WaitForSeconds(group.spawnInterval);
            }
        }

        isSpawning = false;
        GameEvents.WaveCompleted();
    }

    private void SpawnEnemy(GameObject enemyPrefab, string pathID)
    {
        GameObject enemyGO = Instantiate(enemyPrefab);
        EnemyMovement movement = enemyGO.GetComponent<EnemyMovement>();

        if (movement != null)
        {
            PathConfig selectedPath = null;
            foreach (var path in currentLevel.paths)
            {
                if (path.pathID == pathID)
                {
                    selectedPath = path;
                    break;
                }
            }

            if (selectedPath == null && currentLevel.paths.Count > 0)
            {
                selectedPath = currentLevel.paths[0];
            }

            if (selectedPath != null)
            {
                movement.Initialize(selectedPath);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextWave();
        }
    }
}