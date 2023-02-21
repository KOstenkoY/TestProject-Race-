using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _carRigidbody = null;
    [SerializeField] Rigidbody2D _backWheelRigidbody = null;
    [SerializeField] Rigidbody2D _frontWheelRigidbody = null;

    [SerializeField] private float _speed = 50f;

    [SerializeField] private float _delayBeforeDeath = 1.5f;

    private int _direction = 1;

    private bool _isMove = false;
    private bool _isStop = false;

    private const string _groundTag = "Ground";

    private Coroutine _deathCoroutine;

    private void OnEnable()
    {
        InputSystem.OnMove += Move;
        InputSystem.OnStop += Stop;
    }

    private void OnDisable()
    {
        InputSystem.OnMove -= Move;
        InputSystem.OnStop -= Stop;
    }


    private void Move(bool isMove)
    {
        _isMove = isMove;

        _direction = -1;
    }
    
    private void Stop(bool isStop)
    {
        _isStop = isStop;

        _direction = 1;
    }
    
    private void SetTorque()
    {
        _frontWheelRigidbody.AddTorque(_speed * _direction * Time.deltaTime);
        _backWheelRigidbody.AddTorque(_speed * _direction * Time.deltaTime);

    }

    private void Update()
    {
        if (_isMove || _isStop)
        {
            SetTorque();
        }
    }
}
