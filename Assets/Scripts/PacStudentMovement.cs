using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public AudioSource audioSource;
    public AudioClip movingSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = movingSound;
        StartCoroutine(MovePacStudent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MovePacStudent()
    {
        while (true)
        {
            yield return StartCoroutine(MoveDirection(Vector3.right, 1.2f));
            yield return StartCoroutine(MoveDirection(Vector3.down, 1.0f));
            yield return StartCoroutine(MoveDirection(Vector3.left, 1.2f));
            yield return StartCoroutine(MoveDirection(Vector3.up, 1.0f));
        }
    }

    private IEnumerator MoveDirection(Vector3 direction, float distance)
    {
        audioSource.Play();
        float movedDistance = 0f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + (direction * distance);

        while (movedDistance < distance)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (movedDistance / distance));
            movedDistance += speed * Time.deltaTime;
            yield return null;
        }
    }   
}
