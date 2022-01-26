using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacker : MonoBehaviour
{
    [SerializeField] private GameObject characterModel;

    [SerializeField] private GameObject cubePrefab;

    private Queue<GameObject> cubeStack = new Queue<GameObject>();

    private void Start()
    {
        StackCubeOnTop();
        StackCubeOnTop();
        StackCubeOnTop();
    }

    private void StackCubeOnTop()
    {
        characterModel.transform.position += new Vector3(0f, characterModel.transform.localScale.y, 0f);

        GameObject spawnedCube = Instantiate(cubePrefab,
                                             characterModel.transform.position - new Vector3(0f, cubePrefab.transform.localScale.y, 0f),
                                             Quaternion.identity,
                                             characterModel.transform.parent);

        cubeStack.Enqueue(spawnedCube);
    }

    private void RemoveCubesFromBottom(int cubesToRemove)
    {
        for(int i = 0; i < cubesToRemove; i++)
        {
            Destroy(cubeStack.Dequeue().gameObject);
        }

        characterModel.transform.position -= new Vector3(0f, cubePrefab.transform.localScale.y * cubesToRemove, 0f);

        foreach(GameObject cube in cubeStack)
        {
            cube.transform.position -= new Vector3(0f, cubePrefab.transform.localScale.y * cubesToRemove, 0f);
        }
    }
}
