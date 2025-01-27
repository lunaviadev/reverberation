using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 15f;
    public float jumpForce = 100f;
    private bool isGrounded;
    public Transform groundCheck; 
    public LayerMask groundLayer; 
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // movement keys
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);


        //jumping mechanics

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * playerSpeed, moveY);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            Jump();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

}

