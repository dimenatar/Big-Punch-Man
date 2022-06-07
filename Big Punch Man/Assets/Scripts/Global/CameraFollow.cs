using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _cameraDiff;

    private void Update()
    {
        _camera.position = _player.position + _cameraDiff;
    }
}
