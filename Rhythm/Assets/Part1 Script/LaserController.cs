using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    public float bpm = 120f;
    private float beatInterval;

    private float timer = 0f;
    private int beatCount = 0;

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
            
            if (beatCount == 4)
            {
                TriggerEvent();
                
                beatCount = 0;
            }
        }
    }
    public void TriggerEvent()
    {
        Debug.Log("sdfsdf");
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
