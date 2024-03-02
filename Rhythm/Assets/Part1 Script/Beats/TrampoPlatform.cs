using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampoPlatform : MonoBehaviour
{
    public float springForce = 10f; // trampo force
    
    private void Start()
    {
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collide");
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(new Vector2(0, springForce), ForceMode2D.Impulse);
        }
    }
}
