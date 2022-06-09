using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hit;

    private int _damage;
    private float _delayToHit;

    public bool _isInFight;

    public void Initialise(int damage, float delayToHit)
    { 
        _damage = damage;
        _delayToHit = delayToHit;
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
            player.TakeDamage(_damage);
            _hit.Play();
            yield return new WaitForSeconds(_delayToHit);
        }
    }
}
