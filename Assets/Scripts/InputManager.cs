using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInputs : MonoBehaviour
{
    private Vector2 startTouchPosition;

    public Action<float> DragInputEvent;

    private void Update()
    {
        RegisterInput();
    }

    private void RegisterInput()
    {
        if (Input.touchCount < 1)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startTouchPosition = touch.position;
        }

        else if (touch.phase == TouchPhase.Moved)
        {
            float dragInput = touch.position.x - startTouchPosition.x;

            if (DragInputEvent != null)
                DragInputEvent(dragInput);

            startTouchPosition = touch.position;
        }
    }
}
