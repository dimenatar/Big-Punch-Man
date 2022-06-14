using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroups : MonoBehaviour
{
    [SerializeField] private List<EnemyGroup> _groups;

    public List<EnemyGroup> Groups => _groups;

    public void InitialiseGroups(Transform player) => _groups.ForEach(group => group.Initialise(player));

    public int GetEnemyAmount()
    {
        int amount = 0;
        _groups.ForEach(group => amount += group.GetAmount());
        return amount;
    }
}
