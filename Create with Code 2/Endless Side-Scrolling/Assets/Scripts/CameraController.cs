using UnityEngine;

public class CameraController : MonoBehaviour
{

    private AudioSource _camAudioSource;
    private PlayerController _playerControllerScript;
    private void Start()
    {
        _camAudioSource =  GetComponent<AudioSource>();
        _playerControllerScript =  GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_playerControllerScript.gameOver)
        {
            _camAudioSource.Stop();
        }
    }
}
