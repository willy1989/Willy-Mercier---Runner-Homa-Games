using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    [SerializeField] private GameloopManager gameloopManager;

    [SerializeField] private CurrencyManager currencyManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Obstacle_TagName) == true)
            gameloopManager.GameOver();

        if (other.CompareTag(Constants.EndStep_TagName) == true)
            gameloopManager.WinGame();

        if (other.CompareTag(Constants.Gem_TagName) == true)
        {
            currencyManager.AddGems(quantity: 1);
            other.GetComponent<GemAnimation>().PlayGrabAnimation();
            SoundManager.Instance.PlaySound(soundEffect: SoundEffect.GrabGem);
        }
    }
}
