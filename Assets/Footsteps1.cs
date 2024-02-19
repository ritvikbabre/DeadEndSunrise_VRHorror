using System.Collections;
using System.Collections.Generic;
using Unity.Engine;


public class Footsteps : MonoBehaviour
{
    public AudioSource FootstepsSound;
    void Update()
    {
        if (Input.Getkey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            FootstepsSound.enabled = true;
        }
        else
        {
            FootstepsSound.enabled = false;
        }


    }
}