using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // ใส่ prefab ใน Inspector
    public Transform spawnPoint;   // ลาก spawn point มาใส่ Inspector
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnRate);
    }

    void SpawnObstacle()
    {
        if (obstacles == null || obstacles.Length == 0 || spawnPoint == null) return;

        int index = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[index], spawnPoint.position, Quaternion.identity);
    }
}
