using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reborn : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 respawnPoint  = new Vector3(-10, 2, 0); // 初始重生点
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Respawn()
    {
        // reborn at the start position
        rb.transform.position = respawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.y < -3f) // when the player fall out of the scene
        {
            Respawn();
        }
    }
}
