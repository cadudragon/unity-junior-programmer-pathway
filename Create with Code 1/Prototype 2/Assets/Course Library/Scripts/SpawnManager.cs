using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private readonly float spawnRangeX = 17f;
    private readonly float spawnPositionZ = 20f;
    private float maxSpawnTime = 1.8f;
    private readonly float initialDelay = 2f;
    private readonly float minSpawnInterval = 0.5f;

    /// <summary>
    /// Improvement: Used SpawnRandomAnimal recursively & decreasing the maxSpawnTime in order to increase difficulty over time, adding more randomness to the game.
    /// </summary>
    private void Start()
    {
        if (animalPrefabs == null || animalPrefabs.Length == 0)
        {
            Debug.LogError("Animal prefabs array is not set or is empty.");
            return;
        }

        Invoke(nameof(SpawnRandomAnimal), initialDelay);
        InvokeRepeating(nameof(DecreaseMaxSpawnTime), 10f, 10f);
    }

    private void SpawnRandomAnimal()
    {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);

        var spawnInterval = Random.Range(minSpawnInterval, maxSpawnTime);
        Invoke(nameof(SpawnRandomAnimal), spawnInterval);
    }

    private void DecreaseMaxSpawnTime()
    {
        maxSpawnTime -= 0.01f;
        Debug.Log("Max Spawn Time decreased to: " + maxSpawnTime);
    }
}
