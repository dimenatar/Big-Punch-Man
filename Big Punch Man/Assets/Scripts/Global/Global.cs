using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    [SerializeField] private Finish _finish;

    private void Awake()
    {
        _finish.OnFinish += EndLevel;
    }

    public void EndLevel()
    {
        Time.timeScale = 0;
    }
}
