using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private float _delayToGetNewPoint;
    public Transform _player;
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

    public void StartChasing()
    {
        _agent.enabled = true;
        StartCoroutine(MoveToPlayer());
    }

    public void StopChasing()
    {
        StopCoroutine(MoveToPlayer());
        _agent.enabled = false;
    }
     
    private IEnumerator MoveToPlayer()
    {
        while (true)
        {
           // 
            if (_agent.isActiveAndEnabled)
            _agent.SetDestination(_player.position);
            yield return new WaitForSeconds(_delayToGetNewPoint);
        }
    }
}
