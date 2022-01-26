using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    [SerializeField] private GameloopManager gameloopManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Obstacle_TagName) == true)
            gameloopManager.GameOver();
    }
}
