using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Obstacle_TagName) == true)
            KillCharacter();
    }

    private void KillCharacter()
    {
        Destroy(gameObject);
    }
}
