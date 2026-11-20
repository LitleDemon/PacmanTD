using UnityEngine;

[CreateAssetMenu(fileName = "NewPath", menuName = "TD/Path Config")]
public class PathConfig : ScriptableObject
{
    public string pathID;
    public Vector2[] waypoints;
}