using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefabs;
    private readonly Vector3 _spawnPosition = new Vector3(40, 0, 0);
    private readonly float _initialDelay = 2f;

    void Start()
    {
        Invoke(nameof(SpawnRandomObstacle), _initialDelay);
    }

    private void SpawnRandomObstacle()
    {
        var obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[obstacleIndex], _spawnPosition,
            obstaclesPrefabs[obstacleIndex].transform.rotation);

        Invoke(nameof(SpawnRandomObstacle), _initialDelay);
    }
}