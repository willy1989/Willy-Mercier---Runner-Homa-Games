using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private GameObject floor;

    private float leftBoundary;

    private float rightBoundary;

    private float forwardSpeed = 10f;

    private float lateralSpeed = 1f;

    private void Awake()
    {
        leftBoundary = -((floor.transform.localScale.x/2) - transform.localScale.x/2);
        rightBoundary = ((floor.transform.localScale.x/2) - transform.localScale.x/2);

        inputManager.DragInputEvent += MoveLaterally;
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }

    private void MoveLaterally(float Xmovement)
    {
        Vector3 newPosition = transform.position + new Vector3(Xmovement, 0f, 0f) * lateralSpeed * Time.deltaTime;

        if(newPosition.x <= leftBoundary)
            newPosition = new Vector3(leftBoundary, transform.position.y, transform.position.z);

        else if(newPosition.x >= rightBoundary)
            newPosition = new Vector3(rightBoundary, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }
}
