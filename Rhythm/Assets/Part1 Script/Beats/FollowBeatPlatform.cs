using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowBeatPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            StartCoroutine(waiter(2));
        }
    }

    IEnumerator waiter(float waitTime)
    {
        yield return waiter(waitTime);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            yield return waiter(waitTime);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            yield return waiter(waitTime);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            yield return waiter(waitTime);
        }
    }
}
