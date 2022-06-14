using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stages : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private DataLoader _loader;
    [SerializeField] private Finish _finish;
    [SerializeField] private List<Stage> _stages;
    //[SerializeField] private NavMeshSurface _surface;

    private Stage _currentStage;
    private int _currentStageIndex;
    private bool _isUserCompletedAllStages;

    public Stage CurrentStage => _currentStage;
    public int CurrentStageIndex => _currentStageIndex;
    public bool IsUserCompletedAllStages => _isUserCompletedAllStages;

    public event Action<Stage> OnStageChanged;
    public event Action<int> OnStageIndexChanged;

    private void Awake()
    {
        OnStageChanged += _finish.SubscribeFinish;
    }

    public void Initialise(int stage, bool isUserCompleteAllLevels)
    {
        print(stage);
        _currentStageIndex = stage;
        _isUserCompletedAllStages = isUserCompleteAllLevels;
        if (!isUserCompleteAllLevels)
        {
            _currentStage = _stages[stage-1];
        }
        else
        {
            _currentStage = _stages[UnityEngine.Random.Range(0, _stages.Count)];
        }
        var location = Instantiate(_currentStage.gameObject);
        _currentStage = location.GetComponent<Stage>();
        print(_currentStage.StageOrder + _currentStage.Location.name + _currentStageIndex);
        //_currentStage.Location.SetActive(true);
        _currentStage.EnemyGroups.InitialiseGroups(_player);
        OnStageChanged?.Invoke(CurrentStage);
        OnStageIndexChanged?.Invoke(CurrentStageIndex);
        //_surface.BuildNavMesh();
    }

    public void UserCompletedStage()
    {
        print($"CURRENT {_currentStage.StageOrder}");
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
                _currentStage = _stages[_currentStage.StageOrder];
                _currentStageIndex = _currentStage.StageOrder;
            }
        }
        _loader.SaveData();
        print($"NEW LEVEL {_currentStage.StageOrder}");
    }

    private bool IsFinalStage(Stage stage)
    {
        return _stages.IndexOf(stage) == _stages.Count - 1;
    }
}
