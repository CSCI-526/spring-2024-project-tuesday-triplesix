using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public bool beat = false;
    public int pkey = 1;
    public int count = 0;
    public bool moving = false;
    public bool color = false;


    private void Start()
    {
        GameObject gb = gameObject;
        gb.SetActive(true);
    }

    private void Update()
    {
        // Check if the UI object is active
        if (beat)
        {
            StartCoroutine(CheckInputTiming());
        }
        else
        {
            // Handle when UI is not active
        }
    }

    IEnumerator CheckInputTiming()
    {
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.J));

        //yield return new WaitForSeconds(1f);
        float timer = 0f;
        if (pkey==1 && Input.GetKeyDown(KeyCode.J))
        {
            moving = true;
            count += 1;
            timer = 0f;
            pkey = -1;
            yield return new WaitForSeconds(1f);
            color = true;
            pkey = 0;
            moving = false;
            yield return new WaitForSeconds(0.1f);
            color = false;
        }
        else if (pkey==0 && Input.GetKeyDown(KeyCode.K))
        {
            moving = true;
            count += 1;
            timer = 0f;
            pkey = -1;
            yield return new WaitForSeconds(1f);
            color = true;
            pkey = 1;
            moving = false;
            yield return new WaitForSeconds(0.1f);
            color = false;
        }

        yield return null; // Wait for the next frame
    }



}
