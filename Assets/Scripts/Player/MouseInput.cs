using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoSingleton<MouseInput>
{
    private float _lastFrameMousePosX;
    [SerializeField] private float _moveFactorX;

    public float MoveFactorX => _moveFactorX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.Invoke_OnMouseInputDown(Input.mousePosition);
            _lastFrameMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            EventManager.Invoke_OnMouseInputStay(Input.mousePosition);
            _moveFactorX = Input.mousePosition.x - _lastFrameMousePosX;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EventManager.Invoke_OnMouseInputUp(Input.mousePosition);
            _moveFactorX = 0;
        }
        _moveFactorX = Mathf.Clamp(_moveFactorX, -1f, 1f);
    }
}