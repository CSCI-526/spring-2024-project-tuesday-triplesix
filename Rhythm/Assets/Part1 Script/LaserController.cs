using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    public float bpm;
    public int beat;
    private float beatInterval;

    private float timer = 0f;
    private int beatCount = 1;

    void Start()
    {   
        laser.SetActive(false);
        beatInterval = 60f / bpm;

    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= beatInterval)
        {
            timer -= beatInterval;
            beatCount++;
            
            if (beatCount == beat)
            {
                TriggerEvent();
            }
            if (beatCount >= 4)
            {
                beatCount = 0;
            }
        }
    }
    public void TriggerEvent()
    {
        StartCoroutine(ActivateLaser());
    }

    private IEnumerator ActivateLaser()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        laser.SetActive(false);
    }

    // Update is called once per frame
}
