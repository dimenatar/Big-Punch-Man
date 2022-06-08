using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    private int _currentStage = 1;
    private bool _isCompletedAllStages;

    public int CurrentStage => _currentStage;
    public bool IsCompletedAllStages => _isCompletedAllStages;

    public void SaveData(int stage, bool completed)
    {
        _currentStage = stage;
        _isCompletedAllStages = completed;
    }
}
