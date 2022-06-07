using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        print(_joystick.GetTouchPosition);
        _agent.Move(ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed);
    }

    private Vector3 ConvertYVelocityToZ(Vector2 touchPos) => new Vector3(touchPos.x, 0, touchPos.y);
}
