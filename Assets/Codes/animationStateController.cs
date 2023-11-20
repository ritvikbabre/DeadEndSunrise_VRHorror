using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isrunning = animator.GetBool("isRunning");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

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
    }
}
