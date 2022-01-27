using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public Action<int> UpdateGemCountEvent;

    public int GemCount
    {
        get
        {
            return PlayerPrefs.GetInt(Constants.GemCount_PlayerPrefs, 0);
        }

        private set
        {
            if (UpdateGemCountEvent != null)
                UpdateGemCountEvent.Invoke(value);

            PlayerPrefs.SetInt(Constants.GemCount_PlayerPrefs, value);
        }
    }

    public void AddGems(int quantity)
    {
        GemCount += quantity;
    }
}