using UnityEngine;
using UnityEngine.InputSystem;

public class PlaySoundOnMovement : MonoBehaviour
{
    [SerializeField] private InputAction movementAction; // Reference to the movement action in the input action map
    [SerializeField] private AudioClip movementSound;   // Sound to play when movement action is triggered
    private AudioSource audioSource;                    // Reference to the AudioSource

    private void Start()
    {
        // Get reference to the AudioSource attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Subscribe to the movement action's performed event
        movementAction.performed += OnMovementPerformed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        // Check if the movement action was triggered by a key press
        if (context.control.IsPressed())
        {
            // Play the movement sound using the AudioSource
            if (audioSource != null && movementSound != null)
            {
                audioSource.PlayOneShot(movementSound);
            }
        }
    }

    private void OnEnable()
    {
        // Enable the movement action when this component is enabled
        movementAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the movement action when this component is disabled
        movementAction.Disable();
    }
}
