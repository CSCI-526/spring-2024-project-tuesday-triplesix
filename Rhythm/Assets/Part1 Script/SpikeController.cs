using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float bpm = 120f;
    // Here for the fmt string:
    // 0 represents spike down
    // 1 represents spike up
    // now only support length 4
    public string fmt = "0101";
    private float beatInterval;
    private float timer = 0f;
    private int beatCount = 0;
    private float moveHeight = 0;
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
        int nBeats = fmt.Length;
        if (timer >= beatInterval)
        {
            timer -= beatInterval;
            beatCount++;
            Move(fmt[beatCount % nBeats]);
        }
    }
    public void Move(char position)
    {
        if (position == '0') {
            transform.position = new Vector3(transform.position.x, 
                                             downPos, 
                                             transform.position.z);
        } else {
            transform.position = new Vector3(transform.position.x, 
                                             upPos, 
                                             transform.position.z);
        }
    }
}
