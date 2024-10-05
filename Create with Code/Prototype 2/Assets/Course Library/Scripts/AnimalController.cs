using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private readonly float boundarie = -10;
    public float speed = 5.0f;

    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);
        DestroyAnimal();
    }

    private void DestroyAnimal()
    {
        if (transform.position.z < boundarie)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
