using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableCubeCollision : MonoBehaviour
{
    [SerializeField] CharacterMovement characterMovement;

    [SerializeField] CubeStacker cubeStacker;

    private void Awake()
    {
        characterMovement = GetComponentInParent<CharacterMovement>();

        cubeStacker = GetComponentInParent<CubeStacker>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Constants.TopObstacle_TagName) == true)
            characterMovement.Fall(YdistanceToFall: transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.BonusBlock_TagName) == true)
        {
            Destroy(other.gameObject);
            cubeStacker.StackCubeOnTop();
        }
    }
}
