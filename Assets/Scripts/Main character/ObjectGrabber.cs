using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    CubeStacker cubeStacker;

    private void Awake()
    {
        cubeStacker = GetComponentInParent<CubeStacker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.BonusBlock_TagName) == true)
        {
            Destroy(other.gameObject);
            cubeStacker.StackCubeOnTop();
            SoundManager.Instance.PlaySound(soundEffect: SoundEffect.GrabRocket);
        }

        if (other.CompareTag(Constants.Gem_TagName) == true)
        {
            CurrencyManager.Instance.AddGems(quantity: 1);
            other.GetComponent<GemAnimation>().PlayGrabAnimation();
            SoundManager.Instance.PlaySound(soundEffect: SoundEffect.GrabGem);
        }
    }
}
