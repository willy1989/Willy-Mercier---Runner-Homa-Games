using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 startTouchPosition;

    public Action<float> DragInputEvent;

    public Action FirstTimeTouchEvent;

    private bool firstTimeTouch = false;

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
            if (firstTimeTouch == false)
            {
                FirstTimeTouchEvent();
                firstTimeTouch = true;
            }

            float dragInput = (touch.position.x - startTouchPosition.x)/Screen.width;

            if (DragInputEvent != null)
                DragInputEvent(dragInput);

            startTouchPosition = touch.position;
        }
    }

    public void Reset()
    {
        firstTimeTouch = false;
    }
}
