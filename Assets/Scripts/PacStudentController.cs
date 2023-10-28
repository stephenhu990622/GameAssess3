using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float lerpSpeed = 1f;
    private Vector3 lastInput = Vector3.zero;
    private Vector3 currentInput = Vector3.zero;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float lerpTime = 0f;
    private bool isMoving = false;

    void Update()
    {
        HandleInput();

        if (!isMoving)
        {
            TryMove();
        }
        else
        {
            LerpMovement();
        }
    }

    void HandleInput()
    {
        Vector3 desiredDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W))
            desiredDirection = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.A))
            desiredDirection = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.S))
            desiredDirection = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.D))
            desiredDirection = Vector3.right;

        if (desiredDirection != Vector3.zero)
        {
            lastInput = desiredDirection;
            if (isMoving)
            {
                TryMove();
            }
        }
    }

    void TryMove()
    {
        if (lastInput == Vector3.zero) return;
        Vector3 nextPosition = transform.position + lastInput;
        if (IsWalkable(nextPosition))
        {
            currentInput = lastInput;
            StartLerping(nextPosition);
        }
        else
        {
            nextPosition = transform.position + currentInput;
            if (IsWalkable(nextPosition))
            {
                StartLerping(nextPosition);
            }
        }
    }

    void StartLerping(Vector3 targetPos)
    {
        startPosition = transform.position;
        endPosition = targetPos;
        lerpTime = 0f;
        isMoving = true;
    }

    void LerpMovement()
    {
        lerpTime += Time.deltaTime * lerpSpeed;
        transform.position = Vector3.Lerp(startPosition, endPosition, lerpTime);

        if (lerpTime >= 1f)
        {
            isMoving = false;
        }
    }

    bool IsWalkable(Vector3 position)
    {
        return true;
    }
}
