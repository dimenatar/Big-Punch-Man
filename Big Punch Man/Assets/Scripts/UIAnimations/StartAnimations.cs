using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartAnimations : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private RectTransform _restart;
    [SerializeField] private Transform _header;

    [SerializeField] private Vector3 _restartAnimatedPosition;

    [SerializeField] private float _animationDurationToAnimatedScale;
    [SerializeField] private float _animationDurationToDefaultScale;
    [SerializeField] private float _animatedScale;

    public void StartRound()
    {
        Sequence sequence = DOTween.Sequence();

        _tutorial.SetActive(false);
        _header.transform.localScale = Vector3.zero;
        _header.gameObject.SetActive(true); 
        _restart.DOAnchorPos(_restartAnimatedPosition, _animationDurationToAnimatedScale);

        sequence.Append(_header.transform.DOScale(_animatedScale, _animationDurationToAnimatedScale));
        sequence.Append(_header.transform.DOScale(1, _animationDurationToDefaultScale));
        sequence.Play();
    }
}
