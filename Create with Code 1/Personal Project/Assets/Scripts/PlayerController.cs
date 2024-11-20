using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    private Rigidbody _playerRb;
    private float _horizontalInput;
    private float _verticalInput;
    private const float ZBoundary = 6.0f;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Vector3 _lastPosition; // Cache the last position for position updates
    private Vector3 _lastInput;    // Cache the last input for input updates

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _lastPosition = transform.position;
        _lastInput = Vector3.zero;
    }

    private void Update()
    {
        // Check if input has changed
        var currentInput = new Vector3(
            Input.GetAxis(Horizontal), 
            0, 
            Input.GetAxis(Vertical)
        );

        if (currentInput != _lastInput)
        {
            _horizontalInput = currentInput.x;
            _verticalInput = currentInput.z;
            _lastInput = currentInput; // Update the cached input
        }

        // Check if position needs clamping
        if (Mathf.Abs(transform.position.z - _lastPosition.z) > 0.01f)
        {
            ConstrainPlayerPosition();
            _lastPosition = transform.position; // Update the cached position
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var movement = new Vector3(_horizontalInput, 0, _verticalInput) * moveSpeed;
        _playerRb.AddForce(movement);
    }

    private void ConstrainPlayerPosition()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Mathf.Clamp(transform.position.z, -ZBoundary, ZBoundary)
        );
    }
}
