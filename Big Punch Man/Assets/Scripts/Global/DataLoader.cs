using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private Stages _stages;

    private UserData _userData;

    private void Awake()
    {
        Application.quitting += SaveData;
    }

    void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        if (JsonSaver.IsExistsSave("UserData"))
        {
            _userData = JsonSaver.Load<UserData>("UserData");
        }
        else
        {
            _userData = new UserData();
            JsonSaver.Save<UserData>(_userData ,"UserData");
        }
        _stages.Initialise(_userData.CurrentStage, _userData.IsCompletedAllStages);
    }

    private void SaveData()
    {
        _userData.SaveData(_stages.CurrentStageIndex, _stages.IsUserCompletedAllStages);
        JsonSaver.Save<UserData>(_userData, "UserData");
    }
}