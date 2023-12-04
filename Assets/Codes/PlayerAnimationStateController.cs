using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isWalkingRightHash;
    int isWalkingLeftHash;
    int isWalkingBackwardHash;
    int isCrouchingHash;
    int isCrawlingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isWalkingBackwardHash = Animator.StringToHash("isWalkingBackward");
        isCrouchingHash = Animator.StringToHash("isCrouching");
        isCrawlingHash = Animator.StringToHash("isCrawling");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isWalkingBackward = animator.GetBool(isWalkingBackwardHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);
        bool isCrawling = animator.GetBool(isCrawlingHash);

        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool rightPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");
        bool crouchPressed = Input.GetKeyDown(KeyCode.C);
        bool crawlPressed = Input.GetKeyDown(KeyCode.LeftControl);

        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        // if player is walking and not running and presses left shift
        if (!isrunning && (forwardPressed && runPressed))
        {
            animator.SetBool("isRunning", true);
        }

        // if player is running and stops running or stops walking
        if (isrunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }


        // initiate right strafe Animation
        if (!isWalkingRight && rightPressed)
        {
            animator.SetBool("isWalkingRight", true);
        }

        if (isWalkingRight && !rightPressed)
        {
            animator.SetBool("isWalkingRight", false);
        }

        // initiate left strafe Animation
        if (!isWalkingLeft && leftPressed)
        {
            animator.SetBool("isWalkingLeft", true);
        }

        if (isWalkingLeft && !leftPressed)
        {
            animator.SetBool("isWalkingLeft", false);
        }

        // initiate backward walking Animation
        if (!isWalkingBackward && backwardPressed)
        {
            animator.SetBool("isWalkingBackward", true);
        }

        if (isWalkingBackward && !leftPressed)
        {
            animator.SetBool("isWalkingBackward", false);
        }

        // initiate crouch Animation
        if (crouchPressed)
        {
            // Toggle between crouching and standing
            isCrouching = !isCrouching;

            // Set the crouching parameter in the animator
            animator.SetBool("isCrouching", isCrouching);
        }

        // initiate crawl Animation
        if (crawlPressed)
        {
            // Toggle between crouching and standing
            isCrawling = !isCrawling;

            // Set the crouching parameter in the animator
            animator.SetBool("isCrawling", isCrawling);
        }
        
    }
}
