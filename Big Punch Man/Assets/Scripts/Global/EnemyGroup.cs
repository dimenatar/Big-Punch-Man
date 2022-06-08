using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public List<Enemy> Enemies => _enemies;

    public int GetAmount() => _enemies.Count;

    private void Awake()
    {
        for (int i =0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i).GetComponent<Enemy>());
        }
    }
}
