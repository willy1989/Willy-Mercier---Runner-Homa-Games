using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableCubeCollision : MonoBehaviour
{
    CharacterMovement characterMovement;

    CubeStacker cubeStacker;

    private void Awake()
    {
        characterMovement = GetComponentInParent<CharacterMovement>();

        cubeStacker = GetComponentInParent<CubeStacker>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Constants.TopObstacle_TagName) == true)
        {
            characterMovement.Fall(YdistanceToFall: transform.position.y);
        }    
    }

    
}
