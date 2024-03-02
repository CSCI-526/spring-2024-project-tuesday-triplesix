using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
            Debug.Log("You win!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerEntered && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You win!");
        }
    }
}