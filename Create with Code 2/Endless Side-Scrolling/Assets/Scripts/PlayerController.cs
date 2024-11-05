using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    [SerializeField] private float jumpForce = 10f;
    private bool _isGrounded =  true;
    [SerializeField] private float gravityModifier = 2f;
    

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
     _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
     _isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
    }
}