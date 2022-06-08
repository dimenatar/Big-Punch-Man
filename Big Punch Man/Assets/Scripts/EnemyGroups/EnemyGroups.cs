using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroups : MonoBehaviour
{
    [SerializeField] private List<EnemyGroup> _groups;
    [SerializeField] private Transform _player;

    public List<EnemyGroup> Groups => _groups;

    public void InitialiseGroups() => _groups.ForEach(group => group.Initialise(_player));

    public int GetEnemyAmount()
    {
        int amount = 0;
        _groups.ForEach(group => amount += group.GetAmount());
        return amount;
    }
}
