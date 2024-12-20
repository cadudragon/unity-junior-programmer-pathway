using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject powerUp;

    private const float SpawnRangeX = 16.0f;
    private const float EnemySpawnY = 0.75f;
    private const float EnemySpawnZ = 12.0f;
    private const float PowerUpRangeZ = 5.0f;
    
    private const float PowerUpSpawnTime = 5.0f;
    private const float EnemySpawnTime =  1.0f;
    private const float StartDelay =  1.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), StartDelay, EnemySpawnTime);
        InvokeRepeating(nameof(SpawnPowerUp), StartDelay, PowerUpSpawnTime);
        
        SpawnEnemy();
        SpawnPowerUp();
    }
    
    private void SpawnEnemy()
    {
        var randomX = Random.Range(-SpawnRangeX, SpawnRangeX);
        var randomIndex = Random.Range(0, enemies.Length);
        var spawnPosition = new Vector3(randomX, EnemySpawnY, EnemySpawnZ);

        Instantiate(enemies[randomIndex], spawnPosition, enemies[randomIndex].transform.rotation);
    }

    private void SpawnPowerUp()
    {
        var randomX = Random.Range(-SpawnRangeX, SpawnRangeX);
        var randomZ = Random.Range(-PowerUpRangeZ, PowerUpRangeZ);
        var spawnPosition = new Vector3(randomX, EnemySpawnY, randomZ);

        Instantiate(powerUp, spawnPosition, powerUp.transform.rotation);
    }
}