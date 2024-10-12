using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private readonly float spawnLimitXLeft = -22;
    private readonly float spawnLimitXRight = 7;
    private readonly float spawnPosY = 30;

    private readonly float startDelay = 1.0f;
    private readonly float spawnInterval = 4.0f;
    private readonly int minSpawnInterval = 3;
    private readonly int maxSpawnTime = 5;

    void Start()
    {
        Invoke(nameof(SpawnRandomBall), startDelay);
    }

    void SpawnRandomBall()
    {
        Vector3 spawnPos = new(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        var randomIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[randomIndex], spawnPos, ballPrefabs[randomIndex].transform.rotation);
        var spawnInterval = Random.Range(minSpawnInterval, maxSpawnTime);

        Invoke(nameof(SpawnRandomBall), spawnInterval);
    }

}
