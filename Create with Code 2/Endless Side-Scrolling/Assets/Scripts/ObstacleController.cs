using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed = 30;

    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.left);
    }
}
