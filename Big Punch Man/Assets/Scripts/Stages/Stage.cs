using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private int _stageOrder;
    [SerializeField] private GameObject _location;
    [SerializeField] private EnemyGroups _enemyGroups;

    public int StageOrder => _stageOrder;
    public GameObject Location => _location;
    public EnemyGroups EnemyGroups => _enemyGroups;
}
