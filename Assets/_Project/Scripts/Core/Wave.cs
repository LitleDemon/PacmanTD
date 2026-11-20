using System.Collections.Generic;
using UnityEngine;

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
    public string targetPathID;
    public List<SpawnGroup> spawnGroups;
}