using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private SimpleTouchController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _punchAnimationsAmount;
    [SerializeField] private HitRandomizer _hitRandomizer;
    [SerializeField] private Finish _finish;

    private readonly int IDLE = Animator.StringToHash("Idle");
    private readonly int RUN = Animator.StringToHash("Run");
    private readonly int PUNCH = Animator.StringToHash("Punch");
    private readonly int FINISH = Animator.StringToHash("Win");
    private readonly int PUNCH_INDEX = Animator.StringToHash("PunchIndex");


    private void Awake()
    {
        _controller.OnBeginDrag += () => _animator.SetTrigger(RUN);
        _controller.OnEndDrag += () => _animator.SetTrigger(IDLE);
        _hitRandomizer.OnHitChosen += Punch;
        _finish.OnFinish += Win;
    }

    private void Punch(Hits hit)
    {
        // choose random attack
        _animator.SetTrigger(PUNCH);
        _animator.SetInteger(PUNCH_INDEX, (int)hit);

        // _animator.SetInteger(PUNCH_INDEX, Random.Range(0, _punchAnimationsAmount));
        //_animator.SetInteger(PUNCH_INDEX, 3);
    }

    private void Win()
    {
        _animator.SetTrigger(FINISH);
    }
}
