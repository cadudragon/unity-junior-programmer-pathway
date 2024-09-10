using UnityEngine;

/// <summary>
/// IMPROVEMENT: The class name 'CameraController' is more descriptive and appropriate compared to 'FollowPlayer,' which is used in Unity's official example.
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    /// <summary>
    /// IMPROVEMENT: The offset was hardcoded in Unity's official example.
    /// Here, we dynamically calculate the initial camera offset based on the camera's current position.
    /// This way, if the camera's initial position is changed in 3d scene, the script still works correctly.
    /// </summary>
    void Start()
    {
        //n Unity, transform.position returns a copy(not a reference) of the position as a Vector3. That's why this works.
        offset = transform.position;
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
