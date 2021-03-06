using System;
using UnityEngine;

[RequireComponent(typeof(Ragdoll))]
[RequireComponent(typeof(EnemyMove))]
[RequireComponent(typeof(EnemyFight))]
[RequireComponent(typeof(EnemyAnimations))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MaterialChanger))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _delayToHit;
    [SerializeField] private Transform _player;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayNewPoint;

    public bool _trigger;

    private EnemyFight _enemyFight;
    private EnemyMove _enemyMove;
    private EnemyAnimations _enemyAnimations;
    private Ragdoll _ragdoll;
    private MaterialChanger _materialChanger;
    private Rigidbody _rigidBody;

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
        _materialChanger = GetComponent<MaterialChanger>();
        _rigidBody = GetComponent<Rigidbody>();

        OnPlayerEntersTrigger += (player) => _enemyAnimations.Fight();
        OnPlayerEntersTrigger += (player) => _enemyMove.StopChasing();
        OnPlayerEntersTrigger += _enemyFight.StartFight;
        OnPlayerEntersTrigger += (player) => _trigger = true;

        OnPlayerExitsTrigger += _enemyFight.StopFight;
        OnPlayerExitsTrigger += (player) => _enemyAnimations.Run();
        OnPlayerExitsTrigger += (player) => _enemyMove.StartChasing();
        OnPlayerExitsTrigger += (player) => _trigger = false;

        OnStartChasing += () => _rigidBody.isKinematic = false;
        OnStartChasing += _enemyMove.StartChasing;
        OnStartChasing += _enemyAnimations.Run;
        OnDied += _materialChanger.ChangeMaterialToDead;
        OnDied += GetComponent<BodyRemover>().Initialise;
        OnDied += () => Destroy(this);
        _ragdoll.OnFall += () => OnDied?.Invoke();
    }

    public void Initialise(Transform player, int damage = 1, float delayToHit = 0.5f, float delayToGetNewPoint = 0.2f)
    {
        _enemyFight.Initialise(damage, _delayToHit);
        _enemyMove.Initialise(player, delayToGetNewPoint);
    }

    public void Enable()
    {
        if (this)
        OnStartChasing?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            OnPlayerEntersTrigger?.Invoke(other.GetComponent<Player>());
    }

    private void OnTriggerExit(Collider other)
    {
        //print(other.gameObject.name);
        if (other.GetComponent<Player>())
        {
            OnPlayerExitsTrigger?.Invoke(other.GetComponent<Player>());
        }
    }

    private void OnDestroy()
    {
        Destroy(_enemyMove);
        Destroy(_enemyFight);
        Destroy(_enemyAnimations);
    }
}