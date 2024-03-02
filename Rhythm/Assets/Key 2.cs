using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public float speed = 7.0f; // Adjust this value to set the movement speed
    public float amplitude = 0.3f; // Adjust this value to set the movement amplitude

    private float originalY;

    void Start()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the vertical movement using Mathf.Sin for a smooth up-and-down motion
        float verticalMovement = amplitude * Mathf.Sin(Time.time * speed);

        // Set the new position of the GameObject
        transform.position = new Vector3(transform.position.x, originalY + verticalMovement, transform.position.z);
    }
}