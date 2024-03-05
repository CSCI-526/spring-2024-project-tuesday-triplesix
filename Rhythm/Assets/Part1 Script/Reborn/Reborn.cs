using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reborn : MonoBehaviour
{
   private Rigidbody2D rb;
   private Renderer renderer;
   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      renderer = GetComponent<Renderer>();
   }

   private void OnTriggerEnter2D(Collider2D collider2D)
   {
      if (collider2D.CompareTag("Player"))
      {
         GameManager.Instance.respawnPoint = transform.position;
         renderer.material.color = Color.yellow;
         Debug.Log(GameManager.Instance.respawnPoint);
      }
   }
}
