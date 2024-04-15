using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float bpm = 120f;
    private float beatInterval;

    private float timer = 0f;
    private int beatCount = 0;
    private float moveHeight = 0;

    void Start()
    {   
        beatInterval = 60f / bpm;
        moveHeight = transform.localScale.y;
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= beatInterval)
        {
            timer -= beatInterval;
            beatCount++;
            
            if (beatCount % 2 == 0)
            {
                MoveUp();
            } else {
                MoveDown();
            }
        }
    }
    public void MoveUp()
    {
        Debug.Log("move up");
        transform.position = new Vector3(transform.position.x, 
                                             moveHeight, 
                                             transform.position.z);
    }

    public void MoveDown()
    {
        Debug.Log("move down");
        transform.position = new Vector3(transform.position.x, 
                                             0, 
                                             transform.position.z);
    }
}
