using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float dashSpeed;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canDoubleJump = true;
    private bool isDashing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,.2f,groundLayer);
        move();
        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
    }

    void move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity= new Vector2 (moveInput*moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canDoubleJump = true;
        }else if(canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canDoubleJump = false;

        }
    }
    void DoubleJump()
    {

    }
    void dash()
    {

    }



}
