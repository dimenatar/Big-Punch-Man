using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
[RequireComponent(typeof(EnemyFight))]
[RequireComponent(typeof(EnemyAnimations))]
public class Enemy : MonoBehaviour
{
    private EnemyFight _enemyFight;
    private EnemyMove _enemyMove;
    private EnemyAnimations _enemyAnimations;

    public event Action<Player> OnPlayerEntersTrigger;
    public event Action<Player> OnPlayerExitsTrigger;

    private void Awake()
    {
        _enemyFight = GetComponent<EnemyFight>();
        _enemyMove = GetComponent<EnemyMove>();
        _enemyAnimations = GetComponent<EnemyAnimations>();

        OnPlayerEntersTrigger += (player) => _enemyAnimations.Fight();
        OnPlayerEntersTrigger += _enemyFight.StartFight;

        OnPlayerExitsTrigger += (player) => _enemyAnimations.Run();
        OnPlayerExitsTrigger += _enemyFight.StopFight;
    }

    public void Initialise(int damage, float delayToHit, Transform player, float delayToGetNewPoint)
    {
        _enemyFight.Initialise(damage, delayToHit);
        _enemyMove.Initialise(player, delayToGetNewPoint);
    }

    public void Enable()
    {
        _enemyAnimations.Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        OnPlayerEntersTrigger?.Invoke(other.GetComponent<Player>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        OnPlayerExitsTrigger?.Invoke(other.GetComponent<Player>());
    }
}
