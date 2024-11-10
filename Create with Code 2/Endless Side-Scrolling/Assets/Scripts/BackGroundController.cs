using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private float speed = 22;
    private Vector3 _startPos;
    private float _repeatWidth;
    private PlayerController _playerControllerScript;


    void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        MoveBackgroundLeft();
        RepeatBackGround();
    }

    void MoveBackgroundLeft()
    {
        if (!_playerControllerScript.gameOver)
        {
            transform.Translate(Time.deltaTime * speed * Vector3.left);
        }
    }

    void RepeatBackGround()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}