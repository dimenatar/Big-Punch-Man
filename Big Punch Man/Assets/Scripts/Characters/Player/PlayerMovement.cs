using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;

    [SerializeField] private float _finalRotationDuration = 0.5f;
    [SerializeField] private float _finalYRotation;

    private Transform _playerTransform;
    private bool _isMoving = true;

    private void Awake()
    {
        _playerTransform = transform;
        _finish.OnFinish += FinalRotate;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        _agent.Move(ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed);
    }

    private Vector3 ConvertYVelocityToZ(Vector2 touchPos) => new Vector3(touchPos.x, 0, touchPos.y);

    private void FinalRotate()
    {
        _isMoving = false;
        _playerTransform.DORotate(new Vector3(0, _finalYRotation, 0), _finalRotationDuration);
    }
}
