using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAnimation : MonoBehaviour
{
    ParticleSystem gemParticleSystem;

    Animator gemAnimator;

    private void Awake()
    {
        gemParticleSystem = GetComponent<ParticleSystem>();

        gemAnimator = GetComponent<Animator>();
    }

    public void PlayGrabAnimation()
    {
        gemAnimator.SetTrigger(Constants.GemGrabbed_AnimationTrigger);
    }

    public void PlayParticleEffect()
    {
        gemParticleSystem.Play();
    }

    public void StopParticleEffect()
    {
        gemParticleSystem.Stop();
    }
}
