using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip;
    public float volume = 1.0f; // Default volume is set to maximum (1.0f)
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position, volume); // Play the audio clip with specified volume
            hasPlayed = true;
        }
    }
}
