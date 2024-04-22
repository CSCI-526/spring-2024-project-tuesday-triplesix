using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public GC_t gameController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turret") && gameController != null)
        {
            Debug.Log("ssssssss");
            gameController.StartBeat();
        }
    }
}