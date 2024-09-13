using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 5.0f;
    private float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(forwardInput * Time.deltaTime * speed * Vector3.forward);
        transform.Rotate(horizontalInput * Time.deltaTime * speed * Vector3.up);
    }
}
