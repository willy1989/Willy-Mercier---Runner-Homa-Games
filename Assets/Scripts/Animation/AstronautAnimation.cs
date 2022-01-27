using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        animator.SetTrigger(Constants.AstronautIdle_AnimationTrigger);
    }

    public void PlayRunAnimation()
    {
        animator.SetTrigger(Constants.AstronautRun_AnimationTrigger);
    }
}
