using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // our car
    private Transform _player = null;

    [SerializeField] private float _followSpeed = 3f;

    [SerializeField] private Vector3 _startPosition;

    private Vector3 _offset;

    // our target
    public void SetPlayer(GameObject player)
    {
        _player = player.transform;

        transform.position = _startPosition;

        _offset = transform.position - _player.position;
    }

    private void Update()
    {
        if (_player == null)
            Debug.Log("Player quals null. Check CameraFollow Component!");

        Vector3 targetPosition = new Vector3(_player.position.x + _offset.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed);
    }
}
