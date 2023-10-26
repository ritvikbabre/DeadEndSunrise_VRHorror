using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 5f;
    public float sprintMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= sprintMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= sprintMultiplier;
        }
    }
}