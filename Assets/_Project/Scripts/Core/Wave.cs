<<<<<<< HEAD
using System.Collections.Generic;
using UnityEngine;

// Новая группа спавна
[System.Serializable]
public class SpawnGroup
{
    public GameObject enemyPrefab;
    public int count;
    public float spawnInterval;
}

[System.Serializable]
public class Wave
{
    // Путь теперь задается для всей волны целиком
    public string targetPathID;

    // А вот враги внутри волны могут быть разными
    public List<SpawnGroup> spawnGroups;
=======
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int count;
    public float spawnInterval;
    public string targetPathID;
>>>>>>> e51a126d5ed75c262ada9384efe9e5037ca3d758
}