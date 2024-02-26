using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Reborn : MonoBehaviour
{
   private Rigidbody2D rb;
   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   private void OnTriggerEnter2D(Collider2D collider2D)
   {
      if (collider2D.CompareTag("Player"))
      {
         GameManager.Instance.respawnPoint = transform.position;
         Debug.Log(GameManager.Instance.respawnPoint);
      }
   }
}
