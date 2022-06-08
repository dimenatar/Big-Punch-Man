using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private Stages _stages;

    private int _startAmount;
    private int _currentAmount;
    private Stage _currentStage;

    public int StartAmount { get => _startAmount; private set => _startAmount = value; }
    public int CurrentAmount
    {
        get => _currentAmount; set
        {
            _currentAmount = value;
            OnEnemyAmountChanged?.Invoke(_currentAmount);
        }
    }

    public event Action<int> OnEnemyAmountChanged;

    private void Awake()
    {
        _stages.OnStageChanged += Initialise;
        
    }

    private void Start()
    {

    }

    private void Initialise(Stage stage)
    {
        _currentStage = stage;
        _currentStage.EnemyGroups.Groups.ForEach(group => group.Enemies.ForEach(enemy => enemy.OnDied += ReduceCounter));
        SetStartAmount(_currentStage.EnemyGroups.GetEnemyAmount());
    }

    public void ReduceCounter()
    {
        CurrentAmount--;
    }

    private void SetStartAmount(int amount)
    {
        StartAmount = amount;
        CurrentAmount = amount;
    }
}
