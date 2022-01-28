using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("UI elements")]

    [SerializeField] private Button RestartButtonGameOverUI;

    [SerializeField] private Button RestartButtonGameWinUI;

    [SerializeField] private Button RestartButtonGameEndUI;

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject startOverUI;

    [SerializeField] private GameObject gameWinUI;

    [SerializeField] private GameObject endUI;

    [SerializeField] private Text gemCountText;

    private void Awake()
    {
        SetInstance(); 
    }

    private void Start()
    {
        RestartButtonGameOverUI.onClick.RemoveAllListeners();
        RestartButtonGameOverUI.onClick.AddListener(GameloopManager.Instance.ResetGame);

        RestartButtonGameWinUI.onClick.RemoveAllListeners();
        RestartButtonGameWinUI.onClick.AddListener(GameloopManager.Instance.ResetGame);

        RestartButtonGameEndUI.onClick.RemoveAllListeners();
        RestartButtonGameEndUI.onClick.AddListener(GameloopManager.Instance.ResetGame);

        CurrencyManager.Instance.UpdateGemCountEvent += UpdateGemCountText;

        gemCountText.text = CurrencyManager.Instance.GemCount.ToString();
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

    public void ToggleEndUI(bool onOff)
    {
        endUI.SetActive(onOff);
    }

    public void UpdateGemCountText(int gemCount)
    {
        gemCountText.text = gemCount.ToString();
    }
}
