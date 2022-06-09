using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private Stages _stages;

    private UserData _userData;

    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        _userData.SaveData(_stages.CurrentStageIndex, _stages.IsUserCompletedAllStages);
        JsonSaver.Save<UserData>(_userData, "UserData");
    }

    private void LoadData()
    {
        if (JsonSaver.IsExistsSave("UserData"))
        {
            _userData = JsonSaver.Load<UserData>("UserData");
            print($"_userData.CurrentStage {_userData.CurrentStage}");
            print("exists");
        }
        else
        {
            _userData = new UserData();
        }
        _stages.Initialise(_userData.CurrentStage, _userData.IsCompletedAllStages);
    }
}
