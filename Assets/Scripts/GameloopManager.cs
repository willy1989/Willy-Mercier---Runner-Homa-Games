using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameloopManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private CubeStacker cubeStacker;

    [SerializeField] private UIManager uiManager;

    [SerializeField] private CameraManager cameraManager;

    [SerializeField] private AstronautAnimation astronautAnimation;

    private void Awake()
    {
        inputManager.FirstTimeTouchEvent += StartGame;
    }

    private void StartGame()
    {
        characterMovement.EnableMovement(onOff: true);
        uiManager.ToggleStartUI(onOff: false);
        cameraManager.SwitchCamera(Constants.Follow_CameraState);
        astronautAnimation.PlayRunAnimation();
    }

    public void GameOver()
    {
        uiManager.ToggleGameOverUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
        astronautAnimation.PlayIdleAnimation();
        SoundManager.Instance.PlaySound(soundEffect: SoundEffect.Lose);
    }

    public void WinGame()
    {
        uiManager.ToggleGameWinUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
        cameraManager.SwitchCamera(Constants.End_CameraState);
        astronautAnimation.PlayIdleAnimation();
        SoundManager.Instance.PlaySound(soundEffect: SoundEffect.Win);
    }

    public void ResetGame()
    {
        /*inputManager.Reset();
        characterMovement.Reset();
        cubeStacker.Reset();
        uiManager.ToggleGameWinUI(onOff: false);
        uiManager.ToggleGameOverUI(onOff: false);
        uiManager.ToggleStartUI(onOff: true);

        cameraManager.SwitchCamera(Constants.Start_CameraState);
        */

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
