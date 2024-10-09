using System.Collections;
using UnityEngine;

public class BiplaneBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject propeller; 
    [SerializeField] private float rollDuration = 1f; 
    [SerializeField] private float propellerSpeed = 800f; // Speed at which the propeller spins
    [SerializeField] private float speed = 15f; // Forward movement speed of the biplane
    [SerializeField] private float tiltSpeed = 100f; 
    private float _rotationAngle = 180f; // Configurable rotation angle for maneuvers
    /// <summary>
    /// Starting rotation before the roll
    /// </summary>
    private Quaternion initialRotation;
    /// <summary>
    /// Target rotation after the roll
    /// </summary>
    private Quaternion targetRotation;
    /// <summary>
    /// Time elapsed during the roll
    /// </summary>
    private float rollTime = 0f;
    private bool isRolling = false;

    public void MoveForward()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public void Tilt(float input)
    {
        if (Mathf.Abs(input) > 0.01f) // Check if input is significant enough to perform tilt
        {
            transform.Rotate(input * tiltSpeed * Time.deltaTime * Vector3.right);
        }
    }

    // Spin the propeller at a fixed update interval
    public void SpinPropeller()
    {
        propeller.transform.Rotate(0f, 0f, propellerSpeed * Time.fixedDeltaTime, Space.Self);
    }

    public void HandleRoll(AerialManeuver aerialManeuver, bool rollKeyPressed, float rotationAngle)
    {
        if (rollKeyPressed && !isRolling)
        {
            _rotationAngle = rotationAngle;
            StartCoroutine(InitiateRoll(aerialManeuver)); // Start rolling coroutine if not already rolling
        }
    }

    /// <summary>
    /// Coroutine to manage the roll process over time
    /// </summary>
    /// <param name="aerialManeuver"></param>
    /// <returns></returns>
    private IEnumerator InitiateRoll(AerialManeuver aerialManeuver)
    {
        StartRoll(aerialManeuver);
        while (isRolling)
        {
            PerformRoll();
            yield return null; // Wait for the next frame
        }
    }

    /// <summary>
    /// Initialize the roll maneuver with starting and target rotations
    /// </summary>
    /// <param name="aerialManeuver"></param>
    private void StartRoll(AerialManeuver aerialManeuver)
    {
        isRolling = true;
        rollTime = 0.0f;
        initialRotation = transform.rotation; // Save the initial rotation
        targetRotation = initialRotation * GetRotation(aerialManeuver); // Calculate the target rotation based on maneuver
    }

    /// <summary>
    /// Perform the roll maneuver by interpolating between initial and target rotations
    /// </summary>
    private void PerformRoll()
    {
        rollTime += Time.deltaTime;
        float t = rollTime / rollDuration; // Calculate the interpolation factor
        transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);

        if (t >= 1.0f) // Check if the roll is complete
        {
            isRolling = false;
        }
    }

    public Quaternion GetRotation(AerialManeuver am) =>
       am switch
       {
           AerialManeuver.BarrelRoll => Quaternion.Euler(0, 0, _rotationAngle),
           _ => Quaternion.Euler(0, _rotationAngle, 0) 
       };

    public enum AerialManeuver
    {
        BarrelRoll, 
        FlatTurn 
    }
}
