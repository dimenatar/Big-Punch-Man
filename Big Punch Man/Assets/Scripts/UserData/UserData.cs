using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public int CurrentStage { get; private set;}
    public bool IsCompletedAllStages { get; private set; }

    public UserData()
    {
        CurrentStage = 1;
        IsCompletedAllStages = false;
    }

    public void SaveData(int stage, bool completed)
    {
        CurrentStage = stage;
        IsCompletedAllStages = completed;
    }

}
