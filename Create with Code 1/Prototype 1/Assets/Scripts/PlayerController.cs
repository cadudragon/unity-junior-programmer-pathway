using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 18.0f;
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(forwardInput * Time.deltaTime * speed * Vector3.forward);
        transform.Rotate(horizontalInput * Time.deltaTime * speed * Vector3.up);
    }
}
