using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour , Player_movement_input_action.IPlayer_movementActions
{
    private Player_movement_input_action player_input;
    public CharacterController controller;

    public float speed = 5f;
    public float crouchSpeed = 2.5f; // Added crouchSpeed
    public float crawlSpeed = 1.5f; // Added crawlSpeed
    private float velocity_;
    private float gravity_ = -9.81f;
    public float GravityMultiplier = 3.0f;

    private PlayerAnimationStateController animationStateController;

    // Start is called before the first frame update
    void Start()
    {
        player_input = new Player_movement_input_action();
        player_input.Enable();
        player_input.player_movement.SetCallbacks(this);
        controller = GetComponent<CharacterController>();
        animationStateController = GetComponent<PlayerAnimationStateController>(); // Get the PlayerAnimationStateController component
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            velocity_ = -1f;
        }
        else 
        {
            velocity_ += gravity_ * GravityMultiplier * Time.deltaTime;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Check the animation state and adjust the speed accordingly
        if (animationStateController.animator.GetBool(animationStateController.isCrouchingHash))
        {
            speed = crouchSpeed;
        }
        else if (animationStateController.animator.GetBool(animationStateController.isCrawlingHash))
        {
            speed = crawlSpeed;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 10f;
            }
            else
            {
                speed = 5f;
            }
        }

        controller.Move(move*speed*Time.deltaTime);
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speed*2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        } */
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
    }

    void Player_movement_input_action.IPlayer_movementActions.OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    void Player_movement_input_action.IPlayer_movementActions.OnMovement(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    void Player_movement_input_action.IPlayer_movementActions.OnInventory(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}