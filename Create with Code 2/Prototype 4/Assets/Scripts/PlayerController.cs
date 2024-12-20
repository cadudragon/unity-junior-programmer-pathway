using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerUp;

    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerUpIndicator;
    [SerializeField] private Vector3 powerUpIndicatorOffset = new Vector3(0, -0.5f, 0);

    [SerializeField] private float speed;
    private Rigidbody _playerRb;

    private const string VerticalAxis = "Vertical";
    private float _verticalInput;
    private float _powerUpKnockBackForce;

    private void Awake()
    {
        speed = 5.0f;
        _powerUpKnockBackForce = 15.0f;
    }

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis(VerticalAxis);
        UpdatePowerUpIndicatorPosition();
    }

    private void FixedUpdate()
    {
        _playerRb.AddForce(_verticalInput * speed * focalPoint.transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivatePowerUp(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        KnockBackEnemy(collision);
    }

    private void ActivatePowerUp(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    private IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        powerUpIndicator.SetActive(false);
        hasPowerUp = false;
    }

    private void KnockBackEnemy(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * _powerUpKnockBackForce, ForceMode.Impulse);
            Debug.Log($"Collided with: {collision.gameObject.name} with power up set to {hasPowerUp}");
        }
    }

    private void UpdatePowerUpIndicatorPosition()
    {
        if (powerUpIndicator != null)
        {
            powerUpIndicator.transform.position = transform.position + powerUpIndicatorOffset;
        }
    }
}