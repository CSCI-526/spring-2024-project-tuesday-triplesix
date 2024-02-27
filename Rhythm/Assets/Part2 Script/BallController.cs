using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject ball;
    private bool isGrounded = true;

    public float autoMoveSpeed = 20.0f;

    public float jumpForce = 5.0f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Vector3 originalScale;
    public Vector3 squareScale = new Vector3(1, 1, 1);

    public BoxCollider2D childCollider; 
    public Vector2 expandedSize = new Vector2(0.03301108f, 0.3f); 
    public Vector2 originalSize = new Vector2(0.03301108f, 0.8f);
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        AutoMoveRight();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            transform.localScale = squareScale;
        }
        else
        {
            transform.localScale = originalScale;
        }
   
    }

    private void AutoMoveRight()
    {
        rb.velocity = new Vector2(autoMoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(autoMoveSpeed, jumpForce);
        isGrounded = false;
    }
}
