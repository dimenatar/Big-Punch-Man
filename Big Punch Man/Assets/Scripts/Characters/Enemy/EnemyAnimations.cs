using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;

    private readonly int RUN = Animator.StringToHash("Run");
    private readonly int FIGHT = Animator.StringToHash("Fight");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        _animator.enabled = false;
    }

    public void Run() => _animator.SetTrigger(RUN);
    public void Fight() => _animator.SetTrigger(FIGHT);
}
