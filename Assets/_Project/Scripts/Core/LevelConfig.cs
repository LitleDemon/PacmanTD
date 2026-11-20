using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "TD/Level Config")]
public class LevelConfig : ScriptableObject
{
    public string levelName;
    public List<PathConfig> paths;
    public List<Wave> waves;
    public int startingLives = 3;
    public int startingPellets = 100;
}