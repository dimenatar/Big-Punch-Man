using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Ragdoll))]
[RequireComponent(typeof(EnemyMove))]
[RequireComponent(typeof(EnemyFight))]
[RequireComponent(typeof(EnemyAnimations))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _delayToHit;
    [SerializeField] private Transform _player;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayNewPoint;


    private EnemyFight _enemyFight;
    private EnemyMove _enemyMove;
    private EnemyAnimations _enemyAnimations;
    private Ragdoll _ragdoll;
    private Animator _animator;

    public event Action<Player> OnPlayerEntersTrigger;
    public event Action<Player> OnPlayerExitsTrigger;
    public event Action OnStartChasing;
    public event Action OnDied;

    private void Awake()
    {
        _enemyFight = GetComponent<EnemyFight>();
        _enemyMove = GetComponent<EnemyMove>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _ragdoll = GetComponent<Ragdoll>();

        OnPlayerEntersTrigger += (player) => _enemyAnimations.Fight();
        OnPlayerEntersTrigger += (player) => _enemyMove.StopChasing();
        OnPlayerEntersTrigger += _enemyFight.StartFight;

        OnPlayerExitsTrigger += (player) => _enemyAnimations.Run();
        OnPlayerExitsTrigger += (player) => _enemyMove.StartChasing();
        OnPlayerExitsTrigger += _enemyFight.StopFight;

        OnStartChasing += _enemyMove.StartChasing;
        OnStartChasing += _enemyAnimations.Run;

        _ragdoll.OnFall += () => OnDied?.Invoke();
        OnDied += () => Destroy(GetComponent<NavMeshAgent>());
        OnDied += () => Destroy(this);
    }

    private void Start()
    {
        Initialise(_damage, _delayToHit, _player, _delayNewPoint);

        Enable();
    }

    public void Initialise(int damage, float delayToHit, Transform player, float delayToGetNewPoint)
    {
        _enemyFight.Initialise(damage, delayToHit);
        _enemyMove.Initialise(player, delayToGetNewPoint);
    }

    public void Enable()
    {
        OnStartChasing?.Invoke();
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

    private void OnDestroy()
    {
        Destroy(_enemyMove);
        Destroy(_enemyFight);
        Destroy(_enemyAnimations);
    }
}
