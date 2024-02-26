using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;

    [Header("Moving speed")]
    public float speed = 8f;

    float xVelocity;

    [Header("Jump Force")]
    public float jumpForce = 6f;

    int jumpCount;

    [Header("State")]
    public bool isOnGround;

    [Header("GroundCheck")]
    public LayerMask groundLayer;

    //按键设置
    bool jumpPress;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPress = true;
        }
    }

    void FixedUpdate()
    {
        isOnGroundCheck();
        Jump();
    }

    void isOnGroundCheck()
    {
        if (coll.IsTouchingLayers(groundLayer))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void Jump()
    {
        if (isOnGround)
        {
            jumpCount = 1;
        }
        if (jumpPress && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPress = false;
        }
        else if (jumpPress && jumpCount > 0 && !isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpCount--;
            jumpPress = false;
        }
    }
}