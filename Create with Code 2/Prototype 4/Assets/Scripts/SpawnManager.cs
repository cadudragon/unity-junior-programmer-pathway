using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    private const float SpawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }

    private static Vector3 RandomIslandPosition()
    {
        var spawnPosX = Random.Range(-SpawnRange, SpawnRange);
        var spawnPosZ = Random.Range(-SpawnRange, SpawnRange);
        return new Vector3(spawnPosX, 0f, spawnPosZ);
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, RandomIslandPosition(), powerUpPrefab.transform.rotation);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomIslandPosition(), enemyPrefab.transform.rotation);
        }
    }
}