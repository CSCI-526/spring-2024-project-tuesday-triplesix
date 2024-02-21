using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMove : MonoBehaviour
{
    private float speed = 15f;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
