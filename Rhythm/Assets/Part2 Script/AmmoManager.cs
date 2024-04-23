using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AmmoManager : MonoBehaviour
{
    // h:v = 3:1
    private float hSpeed = 25f;
    private float vSpeed = 0f;
    public Image bossHealth;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * hSpeed * Time.deltaTime;
        transform.position += Vector3.up * vSpeed * Time.deltaTime;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        health = bossHealth.fillAmount;
        if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Ammo1")) {
            //health -= 1f;
            health -= 0.08f;
            // Debug.Log("Boss health: -15");
        } else if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Ammo2")) {
            //health -= 1f;
            health -= 0.04f;
            // Debug.Log("Boss health: -10");
        } else if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Ammo3")) {
            //health -= 1f;
            health -= 0.02f;
            // Debug.Log("Boss health: -5");
        }
        bossHealth.fillAmount = Math.Max(health, 0);
        gameObject.SetActive(false);
    }
}
