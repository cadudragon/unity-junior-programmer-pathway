using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private const float Speed = 22;
    private const float LeftBoundary = 15;

    void Update()
    {
        transform.Translate(Time.deltaTime * Speed * Vector3.left);
        if (transform.position.y < -LeftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
