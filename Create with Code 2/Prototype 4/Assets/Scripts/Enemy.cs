using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemyRb;
    public GameObject player;
    private Vector3 _lookDirection;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float slowDownFactor = 0.95f;

    private void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _lookDirection = (player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(_lookDirection * speed);
    }
}