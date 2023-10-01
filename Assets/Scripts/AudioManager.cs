using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip introGame;
    public AudioClip normalGhost;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = introGame;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = normalGhost;
            audioSource.Play();
        }
    }
}
