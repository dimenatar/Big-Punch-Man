using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public List<Enemy> Enemies => _enemies;

    public int GetAmount() => _enemies.Count;
}
