using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AmmoManager_t3 : MonoBehaviour
{
    // h:v = 3:1
    private float hSpeed = 15f;
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
        transform.position += Vector3.right * hSpeed * Time.deltaTime;
        transform.position += Vector3.up * vSpeed * Time.deltaTime;

        health = bossHealth.fillAmount;
        Debug.Log("pos" + transform.position.x);
        if (transform.position.x>46 && gameObject.CompareTag("Ammo1"))
        {
            //health -= 1f;
            health -= 0.12f;
            // Debug.Log("Boss health: -15");
            bossHealth.fillAmount = Math.Max(health, 0);
            gameObject.SetActive(false);
        }
        else if (transform.position.x > 46 && gameObject.CompareTag("Ammo2"))
        {
            //health -= 1f;
            health -= 0.08f;
            bossHealth.fillAmount = Math.Max(health, 0);
            gameObject.SetActive(false);
            // Debug.Log("Boss health: -10");
        }
        else if (transform.position.x > 46 && gameObject.CompareTag("Ammo3"))
        {
            //health -= 1f;
            health -= 0.06f;
            bossHealth.fillAmount = Math.Max(health, 0);
            gameObject.SetActive(false);
            // Debug.Log("Boss health: -5");
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        
    }
}
