using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 2f;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtyParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private Rigidbody _playerRb;
    private Animator _playerAnimator;
    private bool _isGrounded = true;
    [SerializeField] private AudioSource playerAudioSource;
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeInt = Animator.StringToHash("DeathType_int");

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !gameOver)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _playerAnimator.SetTrigger(JumpTrig);
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;
        playerAudioSource.PlayOneShot(jumpSound, 1.0f);
        dirtyParticle.Stop();
    }

    private void GameOver()
    {
        gameOver = true;
        _playerAnimator.SetBool(DeathB, true);
        _playerAnimator.SetInteger(DeathTypeInt, 1);
        dirtyParticle.Stop();
        explosionParticle.Play();
        playerAudioSource.PlayOneShot(crashSound, 1.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            _isGrounded = true;
            dirtyParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
}