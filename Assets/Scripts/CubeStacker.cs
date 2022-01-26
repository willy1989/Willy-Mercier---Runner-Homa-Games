using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacker : MonoBehaviour
{
    [SerializeField] private GameObject characterModel;

    [SerializeField] private GameObject cubePrefab;

    private List<GameObject> cubeStack = new List<GameObject>();

    private Vector3 startPosition;


    private void Awake()
    {
        startPosition = characterModel.transform.position;
    }

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

    public void Reset()
    {
        characterModel.transform.position = startPosition;
    }
}
