using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private readonly float boundarie = 35;
    public float speed = 40.0f;

    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        if (transform.position.z > boundarie)
        {
            Destroy(gameObject);
        }
    }
}
