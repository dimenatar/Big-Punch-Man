using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private List<FinishTrigger> _triggers;

    public event Action OnFinish;

    public void SubscribeFinish(Stage stage)
    {
        stage.FinishTrigger.OnFinish += () => OnFinish?.Invoke();
    }
}
