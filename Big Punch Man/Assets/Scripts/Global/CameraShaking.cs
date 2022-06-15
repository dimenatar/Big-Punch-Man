using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] private PlayerSimpleFight _playerFight;
    [SerializeField] private Transform _camera;

    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _addMagnitudePerKilled = 0.01f;

    private float _magnitude;

    private bool _isShaking;

    private void Awake()
    {
        _playerFight.OnEnemyPunched += StartShaking;
    }

    private void StartShaking()
    {
        if (_isShaking)
        {
            _magnitude += _addMagnitudePerKilled;
        }
        else
        {
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        _isShaking = true;
        float timer = 0;
        // in order to reduce shaking by time
        float currentMagnitude = 0f;

        while (timer < _duration)
        {
            currentMagnitude = (1 - timer / _duration) * _magnitude;

            float x = Random.Range(-1f, 1f) * currentMagnitude;
            float y = Random.Range(-1f, 1f) * currentMagnitude;

            _camera.localPosition = new Vector2(x, y);

            timer += Time.deltaTime;
            yield return null;
        }
        _isShaking = false;
        _magnitude = 0;
    }
}
