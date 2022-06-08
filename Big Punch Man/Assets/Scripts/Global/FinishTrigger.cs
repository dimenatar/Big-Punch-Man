using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FinishTrigger : MonoBehaviour
{
    public event Action OnFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            print("FINISH");
            OnFinish?.Invoke();
        }
    }
}
