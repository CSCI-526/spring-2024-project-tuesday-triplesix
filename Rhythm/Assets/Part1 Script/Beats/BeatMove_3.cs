using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMove_3 : MonoBehaviour
{
    private float speed = 16f;
    public GameObject circle;
    void Update()
    {
        if (transform.position.x + (transform.localScale.x / 2) < circle.transform.position.x - 3) {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
    }
}
