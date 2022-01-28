using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Obstacle_TagName) == true)
            GameloopManager.Instance.GameOver();

        if (other.CompareTag(Constants.EndStep_TagName) == true)
            GameloopManager.Instance.EndGame();

        if (other.CompareTag(Constants.Gem_TagName) == true)
        {
            CurrencyManager.Instance.AddGems(quantity: 1);
            other.GetComponent<GemAnimation>().PlayGrabAnimation();
            SoundManager.Instance.PlaySound(soundEffect: SoundEffect.GrabGem);
        }

        if (other.CompareTag(Constants.Pod_TagName) == true)
        {
            GameloopManager.Instance.WinGame();
        }
    }
}
