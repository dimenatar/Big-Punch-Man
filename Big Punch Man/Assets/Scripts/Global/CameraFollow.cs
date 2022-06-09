using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraDiff;
    [SerializeField] private Player _player;

    private bool _isFollowing = true;

    private void Awake()
    {
        _player.OnDied += () => _isFollowing = false;
    }

    private void Update()
    {
        if (_isFollowing)
        _camera.position = _playerTransform.position + _cameraDiff;
    }
}
