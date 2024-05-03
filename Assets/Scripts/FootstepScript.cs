using UnityEngine;

public class PlayAudioOnMove : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;
    private bool isPlaying = false;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Get the Rigidbody component attached to the player object
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player's velocity is greater than zero
        if (rb.velocity.magnitude > 0)
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
            // If the player's velocity is zero and audio is playing, stop it
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
