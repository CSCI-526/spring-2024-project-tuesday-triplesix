using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody2D rb;
    private bool hasKey = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // destroy key
            // add attribute to player
            hasKey = true;
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
}
