using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _carRigidbody = null;
    [SerializeField] Rigidbody2D _backWheelRigidbody = null;
    [SerializeField] Rigidbody2D _frontWheelRigidbody = null;

    [SerializeField] private float _speed = 250f;
    [SerializeField] private float _carTorque = 10f;

    private int _direction = 1;

    private float _movement;

    private bool _isMove = false;
    private bool _isStop = false;

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
        _frontWheelRigidbody.AddTorque(_speed * _direction * Time.fixedDeltaTime);
        _backWheelRigidbody.AddTorque(_speed * _direction * Time.fixedDeltaTime);

    }

    private void Update()
    {
        if (_isMove || _isStop)
        {
            SetTorque();
        }
    }
}
