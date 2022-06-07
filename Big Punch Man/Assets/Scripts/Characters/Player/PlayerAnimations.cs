using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private SimpleTouchController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _punchAnimationsAmount;

    private readonly int IDLE = Animator.StringToHash("Idle");
    private readonly int RUN = Animator.StringToHash("Run");
    private readonly int PUNCH = Animator.StringToHash("Punch");
    private readonly int PUNCH_INDEX = Animator.StringToHash("PunchIndex");


    private void Awake()
    {
        _controller.OnBeginDrag += () => _animator.SetTrigger(RUN);
        _controller.OnEndDrag += () => _animator.SetTrigger(IDLE);
        _controller.OnEndDrag += Punch;
    }

    private void Punch()
    {
        // choose random attack
        _animator.SetTrigger(PUNCH);
        _animator.SetInteger(PUNCH_INDEX, Random.Range(0, _punchAnimationsAmount));
        //_animator.SetInteger(PUNCH_INDEX, 3);
    }
}