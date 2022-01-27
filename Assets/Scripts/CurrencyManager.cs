using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int GemCount
    {
        get
        {
            return PlayerPrefs.GetInt(Constants.GemCount_PlayerPrefs, 0);
        }

        private set
        {
            PlayerPrefs.SetInt(Constants.GemCount_PlayerPrefs, value);
        }
    }

    public void AddGems(int quantity)
    {
        GemCount += quantity;
    }
}
