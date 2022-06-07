using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private float _delayToGetNewPoint;
    private Transform _player;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        StopChasing();
    }

    public void Initialise(Transform player, float delayToGetNewPoint)
    {
        _player = player;
        _delayToGetNewPoint = delayToGetNewPoint;
    }

    public void StartChasing() => StartCoroutine(MoveToPlayer());
    public void StopChasing() => StopCoroutine(MoveToPlayer());

    private IEnumerator MoveToPlayer()
    {
        while (true)
        {
            _agent.SetDestination(_player.position);
            yield return new WaitForSeconds(_delayToGetNewPoint);
        }
    }
}
