using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Transform _transformToRotate;

    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        _transformToRotate.localRotation = Quaternion.Euler(new Vector3(_transformToRotate.eulerAngles.x, 0, Mathf.Atan2(_joystick.GetTouchPosition.x, _joystick.GetTouchPosition.y) * Mathf.Rad2Deg));
    }
}
