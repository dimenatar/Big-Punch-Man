using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stages : MonoBehaviour
{
    [SerializeField] private List<Stage> _stages;

    private Stage _currentStage;
    private int _currentStageIndex;
    private bool _isUserCompletedAllStages;

    public Stage CurrentStage => _currentStage;
    public int CurrentStageIndex => _currentStageIndex;
    public bool IsUserCompletedAllStages => _isUserCompletedAllStages;

    public event Action<Stage> OnStageChanged;
    public event Action<int> OnStageIndexChanged;

    public void Initialise(int stage, bool isUserCompleteAllLevels)
    {
        _isUserCompletedAllStages = isUserCompleteAllLevels;
        if (!isUserCompleteAllLevels)
        {
            _currentStage = _stages[stage-1];
        }
        else
        {
            _currentStage = _stages[UnityEngine.Random.Range(0, _stages.Count)];
            _currentStage.Location.SetActive(true);
        }
        _currentStageIndex = stage;
        print(_currentStage.StageOrder);
        OnStageChanged?.Invoke(CurrentStage);
        OnStageIndexChanged?.Invoke(CurrentStageIndex);
        _currentStage.EnemyGroups.InitialiseGroups();
    }

    public void UserCompletedStage()
    {
        // if user already completed all stages we keep randomizing "new" stages
        if (_isUserCompletedAllStages)
        {
            _currentStage = _stages[UnityEngine.Random.Range(0, _stages.Count)];
            _currentStageIndex++;
        }
        else
        {
            // if user completed final stage, we write about it and random next
            if (IsFinalStage(CurrentStage))
            {
                _currentStage = _stages[UnityEngine.Random.Range(0, _stages.Count)];
                _currentStageIndex++;
                _isUserCompletedAllStages = true;
            }
            else
            {
                _currentStage = _stages[_currentStageIndex];
                _currentStageIndex = _currentStage.StageOrder;
            }
        }
    }

    private bool IsFinalStage(Stage stage)
    {
        return _stages.IndexOf(stage) == _stages.Count;
    }
}
