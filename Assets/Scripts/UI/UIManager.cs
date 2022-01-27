using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Dependencies")]

    [SerializeField] private GameloopManager gameLoopManager;

    [SerializeField] private CurrencyManager currencyManager;

    [Header("UI elements")]

    [SerializeField] private Button RestartGameButtonGameOverUI;

    [SerializeField] private Button RestartGameButtonGameWinUI;

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject startOverUI;

    [SerializeField] private GameObject gameWinUI;

    [SerializeField] private Text gemCountText;

    private void Awake()
    {
        currencyManager.UpdateGemCountEvent += UpdateGemCountText;

        RestartGameButtonGameOverUI.onClick.RemoveAllListeners();
        RestartGameButtonGameOverUI.onClick.AddListener(gameLoopManager.ResetGame);

        RestartGameButtonGameWinUI.onClick.RemoveAllListeners();
        RestartGameButtonGameWinUI.onClick.AddListener(gameLoopManager.ResetGame);


        gemCountText.text = currencyManager.GemCount.ToString();
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

    public void UpdateGemCountText(int gemCount)
    {
        gemCountText.text = gemCount.ToString();
    }
}
