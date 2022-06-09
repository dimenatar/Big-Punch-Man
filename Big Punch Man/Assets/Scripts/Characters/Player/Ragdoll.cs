using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private float _forceToPunch;
    [SerializeField] private Rigidbody _rigidBodyToPunch;
    [SerializeField] private Collider[] _mainColliders;
    [SerializeField] private bool _isEnemy = true;

    private bool _isFallen;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private bool _isFoundRigids;
    private bool _isFoundColliders;

    public bool IsFallen => _isFallen;

    public event Action OnFall;

    private void Start()
    {
        SetRigidbodyState(true);
        SetColliderState(false);
    }

    public void Fall()
    {
        if (!_isFallen)
        {
            OnFall?.Invoke();

            _isFallen = true;
            SetRigidbodyState(false);
            SetColliderState(true);
        }
    }

    public void Initialise(float forceToPunch)
    {
        _forceToPunch = forceToPunch;
    }

    public void PunchRigidbody()
    {
        Fall();
        _rigidBodyToPunch.AddForce(-transform.forward * _forceToPunch, ForceMode.Impulse);
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
        if (!_isEnemy)
            GetComponent<Rigidbody>().isKinematic = !state;
    }

    private void SetColliderState(bool state)
    {
        if (!_isFoundColliders)
        {
            _colliders = GetComponentsInChildren<Collider>();
            _isFoundColliders = true;
        }
        foreach (Collider collider in _colliders)
        {
            collider.enabled = state;
        }
        foreach (Collider collider in _mainColliders)
        {
            collider.enabled = !state;
        }
    }
}
