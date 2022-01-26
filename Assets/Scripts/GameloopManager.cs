using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameloopManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private CubeStacker cubeStacker;

    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        inputManager.FirstTimeTouchEvent += StartGame;
    }

    private void StartGame()
    {
        characterMovement.EnableMovement(onOff: true);
        uiManager.ToggleStartUI(onOff: false);
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
    }

    public void ResetGame()
    {
        inputManager.Reset();
        characterMovement.Reset();
        cubeStacker.Reset();
        uiManager.ToggleGameWinUI(onOff: false);
        uiManager.ToggleGameOverUI(onOff: false);
        uiManager.ToggleStartUI(onOff: true);
    }
}
