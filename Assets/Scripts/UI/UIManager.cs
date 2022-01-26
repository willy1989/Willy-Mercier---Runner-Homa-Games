using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameloopManager gameLoopManager;

    [SerializeField] private Button RestartGameButton;

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject startOverUI;

    private void Awake()
    {
        RestartGameButton.onClick.RemoveAllListeners();
        RestartGameButton.onClick.AddListener(gameLoopManager.ResetGame);
    }

    public void ToggleGameOverUI(bool onOff)
    {
        gameOverUI.SetActive(onOff);
    }

    public void ToggleStartUI(bool onOff)
    {
        startOverUI.SetActive(onOff);
    }
}
