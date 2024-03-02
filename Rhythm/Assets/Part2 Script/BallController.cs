﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject ball;
    public GameObject foot;
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

    public BossManager bossManager;
    private float moveSpeed = 20f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(foot.transform.position, groundCheckRadius, groundLayer);
        //AutoMoveRight();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //     bossManager.TakeDamage(10);
        // }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.DownArrow))
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
        rb.velocity = new Vector2(0, jumpForce * 0.6f);
        isGrounded = false;

        rb.gravityScale = 2f;
        Invoke("ResetGravity", 0.5f);
    }
}



