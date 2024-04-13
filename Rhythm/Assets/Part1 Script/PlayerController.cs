using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private UI UIObject;
    private Rigidbody2D rb;
    private bool hasKey = false;
    public bool canMove = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UIObject = FindObjectOfType<UI>();
    }

    void Update()
    {
        if(!UIObject.beat && canMove)
        {
            Move();
        }
    }
    
    

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    public void ChangeMovement(bool stat)
    {
        canMove = stat;
    }
}
