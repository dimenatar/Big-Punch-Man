using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private float _delayToGetNewPoint;
    private Transform _player;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Initialise(Transform player, float delayToGetNewPoint)
    {
        _player = player;
        _delayToGetNewPoint = delayToGetNewPoint;
    }

    public void StartChasing() => StartCoroutine(MoveToPlayer());

    private IEnumerator MoveToPlayer()
    {
        while (true)
        {
            _agent.SetDestination(_player.position);
            yield return new WaitForSeconds(_delayToGetNewPoint);
        }
    }
}
