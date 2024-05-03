using UnityEngine;
using UnityEngine.InputSystem;

public class PlaySoundOnMove : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    public AudioClip movementSound;

    private AudioSource audioSource;
    private InputAction moveAction;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Bind the action from the input action map
        moveAction = inputActionAsset.FindAction("Move");
        moveAction.performed += ctx => PlayMovementSound();
        moveAction.canceled += ctx => StopMovementSound();
    }

    private void PlayMovementSound()
    {
        // Play the movement sound if audio source and clip are valid
        if (audioSource != null && movementSound != null)
        {
            audioSource.clip = movementSound;
            audioSource.Play();
        }
    }

    private void StopMovementSound()
    {
        // Stop the movement sound
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
