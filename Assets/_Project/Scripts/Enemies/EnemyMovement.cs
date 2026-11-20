using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Stats Config")]
    public EnemyStats stats;

    private Vector2[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isInitialized = false;

    public float DistanceTravelled { get; private set; } = 0f;

    public void Initialize(PathConfig pathConfig)
    {
        if (pathConfig == null || pathConfig.waypoints.Length == 0) return;

        waypoints = pathConfig.waypoints;
        currentWaypointIndex = 0;
        transform.position = waypoints[0];
        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized || waypoints == null || currentWaypointIndex >= waypoints.Length) return;

        Vector2 targetPosition = waypoints[currentWaypointIndex];

        // Берем скорость из stats!
        float currentSpeed = stats != null ? stats.speed : 2f;
        float step = currentSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        DistanceTravelled += step;

        if (Vector2.Distance(transform.position, targetPosition) < 0.05f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                OnReachEnd();
            }
        }
    }

    private void OnReachEnd()
    {
        Debug.Log("Враг дошел до Пакмана!");
        // if (GameManager.Instance != null) GameManager.Instance.LoseLife();
        Destroy(gameObject);
    }
}