using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private BiplaneBehaviour biplane;
    /// <summary>
    ///  Multiplier for controlling tilt sensitivity

    /// </summary>
    [SerializeField] private float tiltInputMultiplier = 1f;
    /// <summary>
    ///  Input for tilting the plane up or down
    /// </summary>
    private float verticalInput;
    private bool barrelRollKey;
    private bool flatTurnKey;

    void Awake()
    {
        biplane = GetComponent<BiplaneBehaviour>();
    }

    /// <summary>
    /// Handles player input and updates input values.
    /// </summary>
    private void Update()
    {
        verticalInput = -Input.GetAxis("Vertical") * tiltInputMultiplier;
        barrelRollKey = Input.GetKey(KeyCode.B);
        flatTurnKey = Input.GetKey(KeyCode.Space);
    }

    /// <summary>
    /// Processes the biplane's movement, tilt, and maneuvers based on player input.
    /// This method is used for physics calculations and updates in FixedUpdate for consistent results.
    /// </summary>
    void FixedUpdate()
    {
        biplane.MoveForward();
        biplane.Tilt(verticalInput);
        biplane.HandleRoll(BiplaneBehaviour.AerialManeuver.BarrelRoll, barrelRollKey, 180f);
        biplane.HandleRoll(BiplaneBehaviour.AerialManeuver.FlatTurn, flatTurnKey, 180f);
        biplane.SpinPropeller();
    }
}
