using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableCubeCollision : MonoBehaviour
{
    [SerializeField] CharacterMovement characterMovement;

    private void Awake()
    {
        characterMovement = GetComponentInParent<CharacterMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Constants.TopObstacle_TagName) == true)
        {
            characterMovement.Fall(YdistanceToFall: transform.position.y);
        }
    }
}
