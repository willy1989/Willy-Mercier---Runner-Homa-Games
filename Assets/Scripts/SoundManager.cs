using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource stackCubeAudioSource;

    [SerializeField] private AudioSource grabGemAudioSource;

    [SerializeField] private AudioSource grabRocketAudioSource;

    [SerializeField] private AudioSource winAudioSource;

    [SerializeField] private AudioSource loseAudioSource;

    private Dictionary<SoundEffect, AudioSource> audioSourceDictionary = new Dictionary<SoundEffect, AudioSource>();

    private void Awake()
    {
        audioSourceDictionary.Add(SoundEffect.StackCube, stackCubeAudioSource);
        audioSourceDictionary.Add(SoundEffect.GrabGem, grabGemAudioSource);
        audioSourceDictionary.Add(SoundEffect.GrabRocket, grabRocketAudioSource);
        audioSourceDictionary.Add(SoundEffect.Win, winAudioSource);
        audioSourceDictionary.Add(SoundEffect.Lose, loseAudioSource);
    }

    public void PlaySound(SoundEffect soundEffect)
    {
        audioSourceDictionary[soundEffect].Play();
    }
}

public enum SoundEffect
{
    StackCube,
    GrabGem,
    GrabRocket,
    Win,
    Lose
}
