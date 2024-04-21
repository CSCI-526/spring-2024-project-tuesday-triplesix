using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject ball;
    public GameObject foot;
    public bool isGrounded = true;
    public bool isJumping = false;
    public float autoMoveSpeed = 20.0f;

    // public CinemachineVirtualCamera virtualCamera;

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
    public float moveSpeed = 10f;

    private bool canMove = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        // virtualCamera.Follow = null;
        isJumping = false;

    }

    private void Update()
    {
        if (canMove)
        {
            isGrounded = Physics2D.OverlapCircle(foot.transform.position, groundCheckRadius, groundLayer);
            //AutoMoveRight();
            // if (isGrounded && virtualCamera.Follow == null)
            // {
            //     virtualCamera.Follow = transform;
            // }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {   
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            // if (Input.GetKeyDown(KeyCode.J))
            // {
            //     bossManager.TakeDamage(10);
            // }
            if (isGrounded) {
                isJumping = false;
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                Jump();

            }
            // if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            // {
            //     transform.localScale = squareScale;
            // }
            // else
            // {
            //     transform.localScale = originalScale;
            // }
        }


    }
    public void DisableMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }
    public void EnableMovement()
    {
        canMove = true;
    }

    private void AutoMoveRight()
    {
        rb.velocity = new Vector2(autoMoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0, jumpForce * 0.7f);
        isGrounded = false;

        rb.gravityScale = 3f;
        Invoke("ResetGravity", 0.3f);
    }

    private void ResetGravity()
    {
        rb.gravityScale = 6f;
    }


}
