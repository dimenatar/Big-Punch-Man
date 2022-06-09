using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hit;

    private int _damage;
    private float _delayToHit;

    public event Action OnHit;

    public bool _FIGHT;

    private void Update()
    {
        if (_FIGHT)
        {
            //print("Как так то");
        }
    }

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
        if (!_FIGHT)
        {
            _FIGHT = true;
            StartCoroutine(FightWithEnemy(player));
        }
    }
    public void StopFight(Player player)
    {
        _FIGHT = false;
        print("STOP FIGHT");
        //StopCoroutine(FightWithEnemy(player));
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
