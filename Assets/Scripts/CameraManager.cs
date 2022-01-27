using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Animator cameraAnimator;

    private void Awake()
    {
        cameraAnimator = GetComponent<Animator>();
    }

    public void SwitchCamera(string cameraState)
    {
        cameraAnimator.Play(cameraState);
    }
}
