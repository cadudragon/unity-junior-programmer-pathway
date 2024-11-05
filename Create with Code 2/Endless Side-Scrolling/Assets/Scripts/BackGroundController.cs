using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private float speed = 30;
    private Vector3 _startPos;
    private float _repeatWidth;


    void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        MoveBackgroundLeft();
        RepeatBackGround();
    }

    void MoveBackgroundLeft()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.left);
    }

    void RepeatBackGround()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}