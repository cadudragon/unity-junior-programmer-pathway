using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.forward * -speed);
    }
}