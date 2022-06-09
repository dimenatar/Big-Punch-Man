using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private Stages _stages;
    [SerializeField] private Finish _finish;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _panelImage;
    [SerializeField] private GameObject _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private TextMeshProUGUI _result;

    [SerializeField] private float _animationDurationToAnimatedScale = 0.4f;
    [SerializeField] private float _animationDurationToDefaultScale = 0.3f;
    [SerializeField] private float _animatedScale;

    private const string LOSE_TEXT = "COMPLETED";
    private const string LOSE_BUTTON = "RESTART";

    private const string WIN_TEXT = "FAILED";
    private const string WIN_BUTTON = "NEXT";

    private void Awake()
    {
        _player.OnDied += () => ShowPanel(false);
        _finish.OnFinish += () => ShowPanel(true);
    }

    private void ShowPanel(bool win)
    {
        Time.timeScale = 0;
        _button.transform.localScale = Vector3.zero;
        _result.transform.localScale = Vector3.zero;
        _panel.SetActive(true);
        if (win)
        {
            _panelImage.enabled = true;
            _buttonText.text = WIN_BUTTON;
            _result.text = $"LEVEL {_stages.CurrentStageIndex} {WIN_TEXT}";
        }
        else
        {
            _buttonText.text = LOSE_BUTTON;
            _result.text = $"LEVEL {_stages.CurrentStageIndex} {LOSE_TEXT}";
        }

        AniamteUI();
    }

    private void AniamteUI()
    {
        Sequence resultSequence = DOTween.Sequence();
        Sequence buttonSequence = DOTween.Sequence();

        resultSequence.Append(_result.transform.DOScale(_animatedScale, _animationDurationToAnimatedScale));
        resultSequence.Append(_result.transform.DOScale(1, _animationDurationToDefaultScale));

        buttonSequence.Append(_button.transform.DOScale(_animatedScale, _animationDurationToAnimatedScale));
        buttonSequence.Append(_button.transform.DOScale(1, _animationDurationToDefaultScale));

        resultSequence.Play().SetUpdate(true);
        buttonSequence.Play().SetUpdate(true);
    }
}
