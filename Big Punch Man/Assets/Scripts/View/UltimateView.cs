using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UltimateView : MonoBehaviour
{
    [SerializeField] private PlayerUltimate _playerUltimate;
    [SerializeField] private Transform _areaUlt;
    [SerializeField] private GameObject _ultButton;

    [SerializeField] private Sprite _halfUltButton;
    [SerializeField] private Sprite _fullUltButton;

    [SerializeField] private float _animatedButtonScale = 1.1f;
    [SerializeField] private float _buttonAnimationDuration = 0.5f;

    [SerializeField] private float _maxAreaScale = 8;

    [SerializeField] private float _halfUltAreaAlpha = 0.3f;

    [SerializeField] private float _areaScaleAnimationDuration = 0.2f;

    private Tween _buttonLoop;

    private void Awake()
    {
        _playerUltimate.OnUltAmountChanged += ChangeAreaSize;

        _playerUltimate.OnUltimateHalfAvailable += ShowUltButton;
        _playerUltimate.OnUltavateFullAvailable += FullUlt;

        _playerUltimate.OnUltimateStarted += ScaleToZero;
        _playerUltimate.OnUltimateStarted += UltApplyed;
    }

    private void ChangeAreaSize(float value)
    {
        _areaUlt.DOScale(_playerUltimate.UltValue / _playerUltimate.MaxUltValue * _maxAreaScale, _areaScaleAnimationDuration);
    }

    private void ScaleToZero()
    {
        float duration = (_playerUltimate.UltValue / _playerUltimate.MaxUltValue * _playerUltimate.UltDuration);
        _areaUlt.DOScale(0, duration);
    }

    private void ShowUltButton()
    {
        _ultButton.transform.localScale = Vector3.zero;
        _ultButton.SetActive(true);
        _ultButton.transform.DOScale(1, _buttonAnimationDuration);
    }

    private void FullUlt()
    {
        _ultButton.GetComponent<Image>().sprite = _fullUltButton;
        _buttonLoop = _ultButton.transform.DOScale(_animatedButtonScale, _buttonAnimationDuration).SetLoops(-1, LoopType.Yoyo);
        _areaUlt.GetComponent<SpriteRenderer>().color = SetAlpha(_areaUlt.GetComponent<SpriteRenderer>().color, 1);
    }

    private void UltApplyed()
    {
        if (_buttonLoop != null)
        {
            _buttonLoop.Kill();
        }
        _ultButton.GetComponent<Image>().sprite = _halfUltButton;
        _ultButton.SetActive(false);
        _areaUlt.GetComponent<SpriteRenderer>().color = SetAlpha(_areaUlt.GetComponent<SpriteRenderer>().color, _halfUltAreaAlpha);
    }

    private Color SetAlpha(Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }
}