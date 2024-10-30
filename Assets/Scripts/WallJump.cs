using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 10f;
    public float wallSlideSpeed = 2f;
    public Transform wallCheck;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsWall;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckDistance, whatIsWall);

        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (isWallSliding)
            {
                WallJumping();
            }
        }

        Flip();
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void WallJumping()
    {
        rb.velocity = new Vector2(-transform.localScale.x * wallJumpForce, jumpForce);
        isWallSliding = false;
    }

    void Flip()
    {
        if (isFacingRight && Input.GetAxisRaw("Horizontal") < 0)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (!isFacingRight && Input.GetAxisRaw("Horizontal") > 0)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}