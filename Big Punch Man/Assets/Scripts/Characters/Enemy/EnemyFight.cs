using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    private int _damage;
    private float _delayToHit;

    public void Initialise(int damage, float delayToHit)
    { 
        _damage = damage;
        _delayToHit = delayToHit;
    }

    public void StartFight(Player player) => StartCoroutine(FightWithEnemy(player));
    public void StopFight(Player player) => StopCoroutine(FightWithEnemy(player));

    private IEnumerator FightWithEnemy(Player player)
    {
        while (true)
        {
            player.TakeDamage(_damage);
            yield return new WaitForSeconds(_delayToHit);
        }
    }
}
