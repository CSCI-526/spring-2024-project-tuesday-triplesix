using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Vector2 respawnPoint  = new Vector2(-10, 2); // 初始重生点

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasKey = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // destroy key
            // add attribute to player
            hasKey = true;
        }
        else if (other.CompareTag("Enemy"))
        {
            rb.transform.position = respawnPoint;
        }
        else if (other.CompareTag("Door"))
        {
            if (hasKey == true)
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("You haven't got a key yet!");
            }
        }
    }
    
    

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ground1"))
        {
            isGrounded = true;
        }
    }
}
