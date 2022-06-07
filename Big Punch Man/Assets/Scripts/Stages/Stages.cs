using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stages : MonoBehaviour
{
    [SerializeField] private List<Stage> _stages;

    private Stage _currentStage;

    public Stage CurrentStage => _currentStage;

    public event Action<Stage> OnStageChanged;

    public void Initialise(int stage)
    {
        _currentStage = _stages[stage];
        OnStageChanged?.Invoke(CurrentStage);
    }
}
