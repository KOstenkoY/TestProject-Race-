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

    private bool _move = false;
    private bool _stop = false;

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


    private void Move()
    {
        _direction = -1;
        SetTorque(_speed, _direction);
    }
    
    private void Stop()
    {
        _direction = 1;
        SetTorque(_speed, _direction);
    }
    
    private void SetTorque(float speed, int direction)
    {
        _frontWheelRigidbody.AddTorque(_speed * direction);
        _backWheelRigidbody.AddTorque(_speed * direction);

        //_carRigidbody.AddTorque(speed);
    }
}
