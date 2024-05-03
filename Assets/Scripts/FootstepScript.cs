using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlaySoundOnMove : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    public AudioClip movementSound;

    private AudioSource audioSource;
    private InputAction moveAction;
    private bool isMoving = false;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Bind the action from the input action map
        moveAction = inputActionAsset.FindAction("Move");
        moveAction.performed += ctx => OnMovePerformed();
        moveAction.canceled += ctx => OnMoveCanceled();
    }

    private void OnMovePerformed()
    {
        // Set the flag to indicate that movement input is active
        isMoving = true;

        // Play the movement sound if audio source and clip are valid
        if (audioSource != null && movementSound != null && !audioSource.isPlaying)
        {
            audioSource.clip = movementSound;
            audioSource.Play();
        }
    }

    private void OnMoveCanceled()
    {
        // Set the flag to indicate that movement input is inactive
        isMoving = false;

        // Stop the movement sound
        audioSource.Stop();
    }

    private void Update()
    {
        // If the movement input is inactive and the sound is still playing, stop the sound
        if (!isMoving && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
