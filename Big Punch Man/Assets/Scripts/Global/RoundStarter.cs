using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RoundStarter : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnClick;

    private void Awake()
    {
        OnClick.AddListener(() => Destroy(gameObject));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
