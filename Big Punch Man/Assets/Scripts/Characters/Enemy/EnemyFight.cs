using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private float _delayToAnimationHit;

    private int _damage;
    private float _delayToHit;

    public bool _isInFight;

    public event Action OnHit;

    public void Initialise(int damage, float delayToHit)
    { 
        _damage = damage;
        _delayToHit = delayToHit;
        print(_delayToHit);
    }

    private void OnDestroy()
    {
        StopCoroutine(FightWithEnemy(null));
    }

    public void StartFight(Player player)
    {
        if (!_isInFight)
        {
            _isInFight = true;
            StartCoroutine(FightWithEnemy(player));
        }
    }
    public void StopFight(Player player)
    {
        _isInFight = false;
        StopAllCoroutines();
    }

    private IEnumerator FightWithEnemy(Player player)
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayToAnimationHit);
            player.TakeDamage(_damage);
            OnHit?.Invoke();
            yield return new WaitForSeconds(_delayToHit);
        }
    }
}
