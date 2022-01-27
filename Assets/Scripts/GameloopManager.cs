using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameloopManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private CubeStacker cubeStacker;

    [SerializeField] private UIManager uiManager;

    [SerializeField] private CameraManager cameraManager;

    private void Awake()
    {
        inputManager.FirstTimeTouchEvent += StartGame;
    }

    private void StartGame()
    {
        characterMovement.EnableMovement(onOff: true);
        uiManager.ToggleStartUI(onOff: false);
        cameraManager.SwitchCamera(Constants.Follow_CameraState);
    }

    public void GameOver()
    {
        uiManager.ToggleGameOverUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
    }

    public void WinGame()
    {
        uiManager.ToggleGameWinUI(onOff: true);
        characterMovement.EnableMovement(onOff: false);
        cameraManager.SwitchCamera(Constants.End_CameraState);
    }

    public void ResetGame()
    {
        inputManager.Reset();
        characterMovement.Reset();
        cubeStacker.Reset();
        uiManager.ToggleGameWinUI(onOff: false);
        uiManager.ToggleGameOverUI(onOff: false);
        uiManager.ToggleStartUI(onOff: true);

        cameraManager.SwitchCamera(Constants.Start_CameraState);
    }
}
