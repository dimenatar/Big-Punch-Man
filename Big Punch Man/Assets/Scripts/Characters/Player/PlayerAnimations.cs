using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerUltimate _playerUltimate;
    [SerializeField] private SimpleTouchController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _punchAnimationsAmount;
    [SerializeField] private HitRandomizer _hitRandomizer;
    [SerializeField] private Finish _finish;

    #region Animations hashes
    private readonly int IDLE = Animator.StringToHash("Idle");
    private readonly int RUN = Animator.StringToHash("Run");
    private readonly int PUNCH = Animator.StringToHash("Punch");
    private readonly int FINISH = Animator.StringToHash("Win");
    private readonly int PUNCH_INDEX = Animator.StringToHash("PunchIndex");
    private readonly int ULTA_START = Animator.StringToHash("UltStart");
    private readonly int ULTA_END = Animator.StringToHash("UltEnd");
    #endregion

    private void Awake()
    {
        _controller.OnBeginDrag += () => _animator.SetTrigger(RUN);
        _controller.OnEndDrag += () => _animator.SetTrigger(IDLE);
        _hitRandomizer.OnHitChosen += Punch;
        _finish.OnFinish += Win;
        _playerUltimate.OnUltimateStarted += () => StartCoroutine(ChangeWeight(false));
        _playerUltimate.OnUltimateCompleted += () => StartCoroutine(ChangeWeight(true));
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

    private IEnumerator ChangeWeight(bool reduce)
    {
        float timer = 0;
        while (timer < _playerUltimate.GrowAndReduceDuration)
        {
            if (!reduce)
            {
                _animator.SetLayerWeight(2, timer / _playerUltimate.GrowAndReduceDuration);
            }
            else
            {
                _animator.SetLayerWeight(2, 1 - timer / _playerUltimate.GrowAndReduceDuration);
            }
            timer += Time.deltaTime;
            yield return null;
        }
        
    }
}