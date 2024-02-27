using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public bool beat = false;
    public bool pkey = true;
    public int count = 0;
    public bool moving = false;


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
        if (pkey && Input.GetKeyDown(KeyCode.J))
        {
            moving = true;
            count += 1;
            timer = 0f;
            pkey = false;
            yield return new WaitForSeconds(1f);
            moving = false;
        }
        else if (!pkey && Input.GetKeyDown(KeyCode.K))
        {
            moving = true;
            count += 1;
            timer = 0f;
            pkey = true;
            yield return new WaitForSeconds(1f);
            moving = false;
        }

        yield return null; // Wait for the next frame
    }



}
