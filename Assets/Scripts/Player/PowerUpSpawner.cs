using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float spawnRangeX = 10.0f;
    public float spawnRangeY = 10.0f;
    public float spawnDelay = 15.0f;

    private float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > lastSpawnTime + spawnDelay)
        {
            SpawnPowerUp();
            lastSpawnTime = Time.timeSinceLevelLoad;
        }
    }

    private void SpawnPowerUp()
    {
        if (powerUpPrefab != null)
        {
            float x = Random.Range(-spawnRangeX, spawnRangeX);
            float y = Random.Range(-spawnRangeY, spawnRangeY);
            Vector3 spawnLocation = new Vector3(transform.position.x + x, transform.position.y + y, 0);

            Instantiate(powerUpPrefab, spawnLocation, Quaternion.identity);
        }
    }
}