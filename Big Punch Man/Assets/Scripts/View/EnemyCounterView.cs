using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyCounterView : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private Image _slider;
    [SerializeField] private TextMeshProUGUI _procentage;
    [SerializeField] private float _fillDuration = 0.5f;

    private void Awake()
    {
        _enemyCounter.OnEnemyAmountChanged += UpdateValue;
    }

    private void UpdateValue(int currentAmount)
    {
        float ratio = 1 - (float)currentAmount / _enemyCounter.StartAmount;
        //_slider.fillAmount = ratio;
        _slider.DOFillAmount(ratio, _fillDuration);
        _procentage.text = $"{(int)(ratio * 100)}%";
    }
}
