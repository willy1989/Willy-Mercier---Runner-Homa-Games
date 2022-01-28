using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameloopManager : Singleton<GameloopManager>
{
    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private AstronautAnimation astronautAnimation;

    private void Awake()
    {
        SetInstance();
    }

    private void Start()
    {
        InputManager.Instance.FirstTimeTouchEvent += StartGame;
    }

    private void StartGame()
    {
        characterMovement.EnableMovement(onOff: true);
        UIManager.Instance.ToggleStartUI(onOff: false);
        CameraManager.Instance.SwitchCamera(Constants.Follow_CameraState);
        astronautAnimation.PlayRunAnimation();
    }

    public void GameOver()
    {
        UIManager.Instance.ToggleGameOverUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
        astronautAnimation.PlayIdleAnimation();
        SoundManager.Instance.PlaySound(soundEffect: SoundEffect.Lose);
    }

    public void WinGame()
    {
        UIManager.Instance.ToggleGameWinUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
        CameraManager.Instance.SwitchCamera(Constants.End_CameraState);
        astronautAnimation.PlayIdleAnimation();
        SoundManager.Instance.PlaySound(soundEffect: SoundEffect.Win);
    }

    public void EndGame()
    {
        UIManager.Instance.ToggleEndUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
        astronautAnimation.PlayIdleAnimation();
        SoundManager.Instance.PlaySound(soundEffect: SoundEffect.Lose);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
