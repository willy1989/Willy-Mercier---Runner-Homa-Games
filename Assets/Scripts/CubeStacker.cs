using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacker : MonoBehaviour
{
    [SerializeField] private GameObject characterModel;

    [SerializeField] private GameObject cubePrefab;

    private List<GameObject> cubeStack = new List<GameObject>();

    public void StackCubeOnTop()
    {
        characterModel.transform.position += new Vector3(0f, characterModel.transform.localScale.y, 0f);

        GameObject spawnedCube = Instantiate(cubePrefab,
                                             characterModel.transform.position - new Vector3(0f, cubePrefab.transform.localScale.y, 0f),
                                             Quaternion.identity,
                                             characterModel.transform.parent);

        cubeStack.Add(spawnedCube);
    }

    public void DetachCubeFromStack(GameObject cubeToRemove)
    {
        cubeToRemove.transform.parent = null;

        cubeStack.RemoveAt(cubeStack.IndexOf(cubeToRemove));
    }
}
