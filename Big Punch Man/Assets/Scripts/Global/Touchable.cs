using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.EventSystems;
// Touchable component
public class Touchable : Text, IPointerDownHandler
{
    public int asd;
    public event UnityAction OnClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
 
 // Touchable_Editor component, to prevent treating the component as a Text object.
 [CustomEditor(typeof(Touchable))]
public class Touchable_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        // Do nothing
    }
}