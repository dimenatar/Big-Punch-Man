using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageNumberView : MonoBehaviour
{
    [SerializeField] private Stages _stages;
    [SerializeField] private TextMeshProUGUI _stage;

    private void Awake()
    {
        _stages.OnStageIndexChanged += (index) => _stage.text = $"LEVEL {index}";        
    }
}
