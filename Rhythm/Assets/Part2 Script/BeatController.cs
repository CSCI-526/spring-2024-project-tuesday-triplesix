using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeatController : MonoBehaviour
{
    public GameObject circle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Math.Abs(circle.transform.position[0] - transform.position[0]);
    }
}
