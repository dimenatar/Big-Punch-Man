using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    [SerializeField] private PunchPart _ultimatePunchPart;
    [SerializeField] private PlayerSimpleFight _playerFight;
    [SerializeField] private float _ultDuration;
    [SerializeField] private float _maxUltValue;
    [SerializeField] private float _addUltAmountPerKilledEnemy;
    [SerializeField] private float _growAndReduceDuration = 0.2f;
    [Range(0, 1)] [SerializeField] float _ratioInWhichUltIsAvailable;

    private bool _isFullAvailable;
    private bool _isHalfAvailable;
    private bool _isInUltimate;
    private float _ultValue;

    public float UltDuration => _ultDuration;
    public float MaxUltValue => _maxUltValue;
    public float UltValue => _ultValue;
    public bool IsInUltimate => _isInUltimate;

    public event Action<float> OnUltAmountChanged;
    public event Action OnUltimateHalfAvailable;
    public event Action OnUltavateFullAvailable;
    public event Action OnUltimateStarted;
    public event Action OnUltimateCompleted;
    public event Action OnUltimateEnded;

    private void Awake()
    {
        _playerFight.OnEnemyPunched += AddUlt;

        OnUltimateStarted += UltStarted;
        OnUltimateEnded += UltEnded;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void StartUltimate() => StartCoroutine(nameof(UseUltimate));

    private IEnumerator UseUltimate()
    {
        // delay to grow

        OnUltimateStarted?.Invoke();

        yield return new WaitForSeconds(_growAndReduceDuration);
        // wait for ultimate ended
        // mainly for animation
        yield return new WaitForSeconds(_ultValue/_maxUltValue * _ultDuration);
        OnUltimateCompleted?.Invoke();
        _ultValue = 0;
        // delay to reduce animation
        yield return new WaitForSeconds(_growAndReduceDuration);
        OnUltimateEnded?.Invoke();
    }

    private void AddUlt()
    {
        if (!_isInUltimate)
        {
            if (_ultValue + _addUltAmountPerKilledEnemy <= _maxUltValue)
            {
                _ultValue += _addUltAmountPerKilledEnemy;
            }
            else
            {
                _ultValue = _maxUltValue;
            }
            //print(_ultValue);
            OnUltAmountChanged?.Invoke(_ultValue);
            CheckProgress();
        }
    }

    private void CheckProgress()
    {
        if (_ultValue == _maxUltValue && !_isFullAvailable)
        {
            _isFullAvailable = true;
            OnUltavateFullAvailable?.Invoke();
        }
        else if (_ultValue / _maxUltValue >= _ratioInWhichUltIsAvailable && !_isHalfAvailable)
        {
            _isHalfAvailable = true;
            OnUltimateHalfAvailable?.Invoke();
        }
    }

    private void UltStarted()
    {
        _isInUltimate = true;
        _isFullAvailable = false;
        _isHalfAvailable = false;
        _ultimatePunchPart.gameObject.SetActive(true);
    }

    private void UltEnded()
    {
        _isInUltimate = false;
        _ultimatePunchPart.gameObject.SetActive(false);
    }
}