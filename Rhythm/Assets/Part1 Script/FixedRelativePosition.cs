using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRelativePosition : MonoBehaviour
{
    public Transform obj1; // Assign obj1 in the Inspector

    private Vector3 offset; // Store the initial offset between obj1 and obj2

    void Start()
    {
        if (obj1 == null)
        {
            Debug.LogError("obj1 is not assigned! Please assign obj1 in the Inspector.");
            enabled = false; // Disable the script if obj1 is not assigned
            return;
        }

        // Calculate the initial offset between obj1 and obj2
        offset = transform.position - obj1.position;
    }

    void LateUpdate()
    {
        // Update the position of obj2 relative to obj1
        transform.position = obj1.position + offset;
    }
}