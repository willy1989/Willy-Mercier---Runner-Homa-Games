using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Vector2 startTouchPosition;

    public Action<float> DragInputEvent;

    public Action FirstTimeTouchEvent;

    private bool firstTimeTouch = false;

    private void Awake()
    {
        SetInstance();

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

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
            startTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
        }

        else if (touch.phase == TouchPhase.Moved)
        {
            if (firstTimeTouch == false)
            {
                FirstTimeTouchEvent();
                firstTimeTouch = true;
            }

            float dragInput = (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f)).x - startTouchPosition.x);

            if (DragInputEvent != null)
                DragInputEvent(dragInput);

            startTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
        }
    }

    public void Reset()
    {
        firstTimeTouch = false;
    }
}
