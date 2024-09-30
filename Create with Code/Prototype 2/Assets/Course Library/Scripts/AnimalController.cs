using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private readonly float boundarie = -10;
    public float speed = 20.0f;

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
}
