using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action OnDied;

    private void Awake()
    {
        OnDied += () => Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            OnDied?.Invoke();
        }
    }
}
