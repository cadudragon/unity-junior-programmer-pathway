using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private int pointValue;
    [SerializeField] private bool shouldTriggerGameOver;

    private GameManager _gameManager;
    private Rigidbody _targetRb;

    private bool _isMouseDown;
    private const float MaxTorque = 1.5f;
    private const float MinSpeed = 12;
    private const float MaxSpeed = 16;
    private const float RangeX = 4;
    private const float RangeY = 4;
    private const float SpawnPositionX = 1;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ApplyForce();
    }

    private void Update()
    {
        _isMouseDown = Input.GetMouseButton(0);
    }

    private void OnMouseOver()
    {
     
        if (!_gameManager.gameOver &&  _isMouseDown)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.SetScore(pointValue);
        }

        if (shouldTriggerGameOver && _isMouseDown)
        {
            _gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void ApplyForce()
    {
        _targetRb.AddForce(RandomForce, ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque, RandomTorque, RandomTorque, ForceMode.Impulse);
        transform.position = RandomSpawnPosition;
    }

    private static Vector3 RandomForce => Vector3.up * Random.Range(MinSpeed, MaxSpeed);

    private static Vector3 RandomSpawnPosition => new(Random.Range(-RangeX, RangeY), -SpawnPositionX);

    private static float RandomTorque => Random.Range(-MaxTorque, MaxTorque);
}