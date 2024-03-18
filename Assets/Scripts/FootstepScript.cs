using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public AudioSource footstepSound, sprintSound;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                footstepSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepSound.enabled = true;
                sprintSound.enabled = false;
            }   
        }
        else
        {
            footstepSound.enabled = false;
            sprintSound.enabled = false;
        }
    }
}