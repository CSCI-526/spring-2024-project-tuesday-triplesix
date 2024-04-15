using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float bpm = 120f;
    public float moveHeight;
    private float beatInterval;
    private float timer = 0f;
    private int beatCount = 0;
    private float upPos;
    private float downPos;

    void Start()
    {   
        beatInterval = 60f / bpm;
        moveHeight = transform.localScale.y;
        upPos = transform.position.y + moveHeight;
        downPos = transform.position.y;
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
                                             upPos, 
                                             transform.position.z);
    }

    public void MoveDown()
    {
        Debug.Log("move down");
        transform.position = new Vector3(transform.position.x, 
                                             downPos, 
                                             transform.position.z);
    }
}
