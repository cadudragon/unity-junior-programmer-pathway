using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;
    private const float MaxTorque = 1.5f;
    private const float MinSpeed = 12;
    private const float MaxSpeed = 16;
    private const float RangeX = 4;
    private const float RangeY = 4;
    private const float SpawnPositionX = 1;

    private void Start()
    {
        ApplyForce();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void ApplyForce()
    {
        _targetRb = GetComponent<Rigidbody>();
        _targetRb.AddForce(RandomForce, ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque, RandomTorque, RandomTorque, ForceMode.Impulse);
        transform.position = RandomSpawnPosition;
    }

    private static Vector3 RandomForce => Vector3.up * Random.Range(MinSpeed, MaxSpeed);

    private static Vector3 RandomSpawnPosition => new(Random.Range(-RangeX, RangeY), -SpawnPositionX);

    private static float RandomTorque => Random.Range(-MaxTorque, MaxTorque);
}