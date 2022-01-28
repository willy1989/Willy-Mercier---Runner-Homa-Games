using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Animator cameraAnimator;

    private void Awake()
    {
        SetInstance();

        cameraAnimator = GetComponent<Animator>();
    }

    public void SwitchCamera(string cameraState)
    {
        cameraAnimator.Play(cameraState);
    }
}
