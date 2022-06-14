using System.Collections;
using UnityEngine;


public class EnemyView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private EnemyFight _enemy;

    private void Awake()
    {
        _enemy.OnHit += () => _hit.Play();
    }
}
