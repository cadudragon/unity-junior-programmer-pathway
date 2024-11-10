using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefabs;
    private readonly Vector3 _spawnPosition = new Vector3(40, 0, 0);
    private readonly float _initialDelay = 2f;
    private PlayerController _playerControllerScript;

    void Start()
    {
        Invoke(nameof(SpawnRandomObstacle), _initialDelay);
        _playerControllerScript =  GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnRandomObstacle()
    {
        if (_playerControllerScript.gameOver) return;
        var obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[obstacleIndex], _spawnPosition,
            obstaclesPrefabs[obstacleIndex].transform.rotation);

        
        Invoke(nameof(SpawnRandomObstacle), _initialDelay);
    }
}