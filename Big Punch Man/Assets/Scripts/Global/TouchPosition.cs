using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TouchPosition : MonoBehaviour
{
    [SerializeField] private GameObject _touch;
    [SerializeField] private SimpleTouchController _controller;
    [SerializeField] private Camera _main;

    private bool _isShown = true;
    private bool _isHolding;

    private void Start()
    {
        _controller.gameObject.SetActive(false);
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (_isShown)
        {
            // if (!_isHodling && Input.touchCount > 0)
            if (!_isHolding && Input.GetMouseButtonDown(0))
            {
                // _touch.transform.position = _main.ScreenToWorldPoint(Input.GetTouch(0).position);
                _touch.transform.position = Input.mousePosition;
                _controller.BeginDrag();
                _touch.SetActive(true);
                _isHolding = true;
            }
        }
        // if (Input.touchCount > 0 && _isHodling)
        if (_isHolding)
        {
            //Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            if (Input.GetMouseButtonUp(0))
            {
                _isHolding = false;
                _touch.SetActive(false);
                _controller.EndDrag();
            }
        }
    }


    public void DisalbeTouch()
    {
        _controller.gameObject.SetActive(false);
        _isShown = false;
    }

    public void Enabletouch() => _isShown = true;
}
