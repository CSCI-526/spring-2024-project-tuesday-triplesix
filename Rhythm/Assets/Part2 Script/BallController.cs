using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject ball;
    private bool isGrounded = true;

    // 自动运动的速度
    public float autoMoveSpeed = 20.0f;

    // 跳跃的力量
    public float jumpForce = 5.0f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Vector3 originalScale; // 用于存储原始尺寸
    public Vector3 squareScale = new Vector3(1, 1, 1);

    public BoxCollider2D childCollider; // 在 Inspector 中设置这个，拖拽子对象的 BoxCollider2D 到这里
    public Vector2 expandedSize = new Vector2(0.03301108f, 0.3f); // 按下空格时 BoxCollider2D 的大小
    public Vector2 originalSize = new Vector2(0.03301108f, 0.8f);
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; // 在开始时保存原始尺寸

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // 自动向右移动
        AutoMoveRight();

        // 检测是否按下跳跃键
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            // 按下 Ctrl 时变成正方形
            transform.localScale = squareScale;
        }
        else
        {
            // 松开 Ctrl 时恢复原始尺寸
            transform.localScale = originalScale;
        }
   
    }

    private void AutoMoveRight()
    {
        // 球自动向右移动
        rb.velocity = new Vector2(autoMoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        // 向右和向上同时施加力
        rb.velocity = new Vector2(autoMoveSpeed, jumpForce);
        isGrounded = false;
    }
}
