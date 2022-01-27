using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constants.StackableBlock_TagName))
        {
            CubeStacker cubeStacker = other.GetComponentInParent<CubeStacker>();

            if (cubeStacker != null)
            {
                cubeStacker.DetachCubeFromStack(other.gameObject);
            }
                
        } 
    }
}
