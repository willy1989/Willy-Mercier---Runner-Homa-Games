using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameloopManager gameLoopManager;

    [SerializeField] private Button RestartGameButtonGameOverUI;

    [SerializeField] private Button RestartGameButtonGameWinUI;

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject startOverUI;

    [SerializeField] private GameObject gameWinUI;

    private void Awake()
    {
        RestartGameButtonGameOverUI.onClick.RemoveAllListeners();
        RestartGameButtonGameOverUI.onClick.AddListener(gameLoopManager.ResetGame);

        RestartGameButtonGameWinUI.onClick.RemoveAllListeners();
        RestartGameButtonGameWinUI.onClick.AddListener(gameLoopManager.ResetGame);
    }

    public void ToggleGameOverUI(bool onOff)
    {
        gameOverUI.SetActive(onOff);
    }

    public void ToggleStartUI(bool onOff)
    {
        startOverUI.SetActive(onOff);
    }

    public void ToggleGameWinUI(bool onOff)
    {
        gameWinUI.SetActive(onOff);
    }
}
