using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private float _delayToStand = 3;
    [SerializeField] private float _standUpDuration = 0.5f;
    [SerializeField] private bool _isStangingAfterFalling = true;
    [SerializeField] private float _forceToPunch;

    [SerializeField] private Collider[] _mainColliders;
    [SerializeField] private Rigidbody _head;

    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rigidbodyToPunch;

    [SerializeField] private Transform _camera;

    private bool _isFallen;
    private bool _isInitialised;
    private Rigidbody[] _rigidbodies;
    private bool _isFoundRigids;
    private Vector3 _saveHipPos;

    private bool _isStandingSave;
    private float _timer;
    private List<Vector3> _temp;
    private List<Quaternion> _temp2;

    public bool IsFallen => _isFallen;
    public float StandUpDuration => _standUpDuration;

    public event Action OnFall;
    public event Action OnBeginStanding;
    public event Action OnStandedUp;

    private void Awake()
    {
        OnStandedUp += ReturnValuesToStanded;
    }

    private void Start()
    {
        SetRigidbodyState(true);
        SetColliderState(false);
       //Invoke(nameof(Fall), 2f);
    }

    public void Initialise()
    {
        if (_isInitialised)
        {
            _isStangingAfterFalling = _isStandingSave;
        }
        else
        {
            _isStandingSave = _isStangingAfterFalling;
            _isInitialised = true;
        }
    }

    public void Fall()
    {
        if (!_isFallen)
        {
            OnFall?.Invoke();

            _isFallen = true;
            SetRigidbodyState(false);
            SetColliderState(true);

            if (_isStangingAfterFalling)
                Invoke(nameof(Stand), _delayToStand);
        }
    }


    private void Stand()
    {
        if (_isStangingAfterFalling)
        OnBeginStanding?.Invoke();
    }

    public void PunchRigidbody()
    {
        print("PUNCH");
        Fall();
         _rigidbodyToPunch.AddForce(-transform.forward * _forceToPunch, ForceMode.Impulse);
    }

    public void Restore()
    {
        SetRigidbodyState(true);
        SetColliderState(false);
        _isFallen = false;
        OnStandedUp?.Invoke();
    }

    public void FullyFall()
    {
        _isStangingAfterFalling = false;
        PunchRigidbody();
        //Fall();
    }

    private void SetRigidbodyState(bool state)
    {
        if (!_isFoundRigids)
        {
            _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList().Where(r => r.name != gameObject.name).ToArray();
            _isFoundRigids = true;
        }
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }

    private void SetColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
        foreach (Collider collider in _mainColliders)
        {
            collider.enabled = !state;
        }
    }

    private void ReturnValuesToStanded()
    {
        SetRigidbodyState(true);
        SetColliderState(false);
       // _playerAnimator.enabled = true;
        _isFallen = false;
    }
}
