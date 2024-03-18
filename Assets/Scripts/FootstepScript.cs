using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnMove : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector3 lastPosition;
    private bool isPlaying = false;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Store the initial position
        lastPosition = transform.position;
    }

    void Update()
    {
        // Check if the position has changed since the last frame
        if (transform.position != lastPosition)
        {
            // If audio is not already playing, start playing it
            if (!isPlaying && audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
        else
        {
            // If the position hasn't changed and audio is playing, stop it
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }

        // Update the lastPosition to the current position
        lastPosition = transform.position;
    }
}
