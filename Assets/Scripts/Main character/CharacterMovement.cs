using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private float leftBoundary;

    private float rightBoundary;

    private float forwardSpeed = 10f;

    private float lateralSpeed = 40f;

    private float fallSpeed = 8f;

    private bool canMove;

    private Vector3 startPosition;

    private void Awake()
    {
        leftBoundary = -((floor.transform.localScale.x/2) - transform.localScale.x/2);
        rightBoundary = ((floor.transform.localScale.x/2) - transform.localScale.x/2);

        startPosition = transform.position;
    }

    private void Start()
    {
        InputManager.Instance.DragInputEvent += MoveLaterally;
    }

    private void Update()
    {
        MoveForward();
    }

    public void EnableMovement(bool onOff)
    {
        canMove = onOff;
    }

    private void MoveForward()
    {
        if (canMove == false)
            return;

        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }

    private void MoveLaterally(float Xmovement)
    {
        if (canMove == false)
            return;

        Vector3 newPosition = transform.position + new Vector3(Xmovement, 0f, 0f) * lateralSpeed * Time.deltaTime;

        if(newPosition.x <= leftBoundary)
            newPosition = new Vector3(leftBoundary, transform.position.y, transform.position.z);

        else if(newPosition.x >= rightBoundary)
            newPosition = new Vector3(rightBoundary, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }

    public void Fall(float YdistanceToFall)
    {
        // Get lowest stackable cube height

        StartCoroutine(FallCoroutine(YdistanceToFall));
    }

    private IEnumerator FallCoroutine(float YdistanceToFall)
    {
        float YdistanceTraveled = 0f;

        float startYPosition = transform.position.y;

        while(YdistanceToFall > YdistanceTraveled)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            YdistanceTraveled -= (Vector3.down * fallSpeed * Time.deltaTime).y;

            yield return null;
        }

        transform.position = new Vector3(transform.position.x, startYPosition - YdistanceToFall, transform.position.z);
    }

    public void Reset()
    {
        transform.position = startPosition;
    }
}
