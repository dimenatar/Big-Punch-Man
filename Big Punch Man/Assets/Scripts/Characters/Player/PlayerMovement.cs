using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5;

    private void FixedUpdate()
    {
        print(_joystick.GetTouchPosition);
        //RotatePlayer();   
        _rigidbody.velocity = ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed;
    }

    private Vector3 ConvertYVelocityToZ(Vector2 touchPos) => new Vector3(touchPos.x, 0, touchPos.y);
}
