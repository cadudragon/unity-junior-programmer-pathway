using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private bool shootProjectile;
    public float speed = 5.0f;
    private const float leftBoundary = -10.0f;
    private const float rightBoundary = 10.0f;

    public GameObject projectilePreFab;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        shootProjectile = Input.GetKeyDown(KeyCode.Space);
        ShootProjectile();
    }

    /// <summary>
    /// IMPROVEMENT:  Using  Mathf.Clamp instead of if statments to set boundaries, used Direct Positioning instead of translate for the current cenario
    /// </summary>
    private void FixedUpdate()
    {
        // Move the player based on input
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Calculate the new position based on input and speed
        float move = speed * Time.fixedDeltaTime * horizontalInput;
        Vector3 newPosition = transform.position + Vector3.right * move;

        // Clamp the new position within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);


        // Update the player's position
        transform.position = newPosition;
    }

    private void ShootProjectile()
    {

        //Debug.Log($"shootProjectile : {shootProjectile}]");
        if (shootProjectile)
        {
            Instantiate(projectilePreFab, transform.position, projectilePreFab.transform.rotation);
        }
    }
}
