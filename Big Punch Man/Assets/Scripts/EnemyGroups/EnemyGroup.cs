using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private EnemyGroupTrigger _trigger;
    public List<Enemy> Enemies => _enemies;

    public int GetAmount() => _enemies.Count;

    public event Action OnActivate;

    private void Awake()
    {
       // _enemies = GetComponentsInChildren<Enemy>().ToList();
        _trigger.OnActivate += () => OnActivate?.Invoke();
        SubscribeEnemies();
    }

    private void SubscribeEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.OnDied -= OnActivate;
            enemy.OnDied += () => _enemies.Remove(enemy);
            OnActivate += enemy.Enable;
        }
    }

    public void Initialise(Transform player)
    {
        //_enemies.ForEach(enemy => enemy.Initialise(player));
        foreach (var enemy in _enemies)
        {
            if (enemy)
            {
                enemy.Initialise(player);
            }
        }
    }
}
