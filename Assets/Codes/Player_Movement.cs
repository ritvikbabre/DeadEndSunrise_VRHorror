using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 5f;
    private float velocity_;
    private float gravity_ = -9.81f;
    public float GravityMultiplier = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

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

        controller.Move(move*speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed*2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
    }
}