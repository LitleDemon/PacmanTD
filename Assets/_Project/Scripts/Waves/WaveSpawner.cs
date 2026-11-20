using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Level Settings")]
    public LevelConfig currentLevel; // Сюда перетащим ассет уровня

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    // Этот метод будет вызывать UI (Человек Б) по кнопке "Старт"
    public void StartNextWave()
    {
        if (isSpawning) return; // Защита от спама кнопки
        if (currentWaveIndex >= currentLevel.waves.Count)
        {
            Debug.Log("Все волны пройдены!");
            GameEvents.LevelCompleted();
            return;
        }

        StartCoroutine(SpawnWaveRoutine(currentLevel.waves[currentWaveIndex]));
        currentWaveIndex++;
    }

    private IEnumerator SpawnWaveRoutine(Wave wave)
    {
        isSpawning = true;
        Debug.Log($"Началась волна {currentWaveIndex}");

<<<<<<< HEAD
        // Проходимся по всем группам врагов в этой волне
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
=======
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave);
            // Ждем указанное время перед спавном следующего
            yield return new WaitForSeconds(wave.spawnInterval);
        }

        isSpawning = false;
        GameEvents.WaveCompleted(); // Сообщаем UI, что волна закончилась
    }

    private void SpawnEnemy(Wave wave)
    {
        GameObject enemyGO = Instantiate(wave.enemyPrefab);
>>>>>>> e51a126d5ed75c262ada9384efe9e5037ca3d758
        EnemyMovement movement = enemyGO.GetComponent<EnemyMovement>();

        if (movement != null)
        {
<<<<<<< HEAD
            PathConfig selectedPath = null;
            foreach (var path in currentLevel.paths)
            {
                if (path.pathID == pathID)
=======
            // Ищем путь, который указан в волне (для уровней 2 и 3)
            PathConfig selectedPath = null;
            foreach (var path in currentLevel.paths)
            {
                if (path.pathID == wave.targetPathID)
>>>>>>> e51a126d5ed75c262ada9384efe9e5037ca3d758
                {
                    selectedPath = path;
                    break;
                }
            }

<<<<<<< HEAD
=======
            // Если путь не указан или не найден, берем первый попавшийся
>>>>>>> e51a126d5ed75c262ada9384efe9e5037ca3d758
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

    // Временная кнопка для теста (пока Человек Б не сделал UI)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextWave();
        }
    }
}