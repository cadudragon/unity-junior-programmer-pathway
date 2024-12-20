using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _horizontalInput * rotationSpeed * Time.deltaTime);
    }
}