using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    [SerializeField] private GameObject _confetti;
    [SerializeField] private Finish _finish;

    private void Awake()
    {
        _finish.OnFinish += () => _confetti.SetActive(true);
    }
}
