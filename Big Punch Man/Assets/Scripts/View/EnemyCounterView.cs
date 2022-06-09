using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounterView : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private Image _slider;
    [SerializeField] private TextMeshProUGUI _procentage;

    private void Awake()
    {
        _enemyCounter.OnEnemyAmountChanged += UpdateValue;
    }

    private void UpdateValue(int currentAmount)
    {
        float ratio = 1 - (float)currentAmount / _enemyCounter.StartAmount;
        _slider.fillAmount = ratio;
        _procentage.text = $"{(int)(ratio * 100)}%";
    }
}
