using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupTrigger : MonoBehaviour
{
    public event Action OnActivate;

    private bool _isActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActivated)
        {
            if (other.GetComponent<Player>())
            {
                OnActivate?.Invoke();
                _isActivated = true;
            }
        }
    }
}
