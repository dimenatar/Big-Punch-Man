using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraDiff;
    [SerializeField] private Player _player;

    [SerializeField] private Vector3 _finalCameraAnimatedPosition;
    [SerializeField] private float _finalCameraMoveDuration = 2;
    [SerializeField] private float _smoothCamera = 0.35f;

    private bool _isFollowing = true;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _player.OnDied += () => _isFollowing = false;
        _finish.OnFinish += DoFinalCameraMove;
    }

    private void LateUpdate()
    {
        if (_isFollowing)
        {
             _camera.position = _playerTransform.position + _cameraDiff;
            // var position = _playerTransform.position + _cameraDiff;
            // _camera.position = Vector3.SmoothDamp(_camera.position, position, ref _velocity, _smoothCamera);

        }


    }

    private void DoFinalCameraMove()
    {
        _isFollowing = false;
        _camera.SetParent(_playerTransform);
        _camera.DOLocalMove(_finalCameraAnimatedPosition, _finalCameraMoveDuration).SetUpdate(true);
    }
}
