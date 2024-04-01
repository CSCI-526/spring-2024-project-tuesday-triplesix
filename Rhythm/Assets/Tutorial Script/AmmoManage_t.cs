using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AmmoManage_t : MonoBehaviour
{
    // h:v = 3:1
    private float hSpeed = 3f;
    private float vSpeed = 1f;
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
        Debug.Log("ammo tag:" + gameObject.tag);
        Debug.Log("ammo pos:" + transform.position.x);
        health = bossHealth.fillAmount;
        if (transform.position.x > 100f && gameObject.CompareTag("Ammo1")) {
            health -= 0.2f;
            gameObject.SetActive(false);
        }
        if (transform.position.x > 100f && gameObject.CompareTag("Ammo2")){
            health -= 0.1f;
            gameObject.SetActive(false);
        } 
        if (transform.position.x > 100f && gameObject.CompareTag("Ammo3")) {
            health -= 0.05f;
            gameObject.SetActive(false);
        } 
        bossHealth.fillAmount = Math.Max(health, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Triggered");
        Debug.Log("gameObject:" + gameObject.tag);
        Debug.Log("collision:" + collision.gameObject.tag);
        health = bossHealth.fillAmount;
        if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Ammo1")) {
            health -= 0.12f;
            // Debug.Log("Boss health: -15");
        } else if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Ammo2")) {
            health -= 0.08f;
            // Debug.Log("Boss health: -10");
        } else if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Ammo3")) {
            health -= 0.03f;
            // Debug.Log("Boss health: -5");
        }
        bossHealth.fillAmount = Math.Max(health, 0);
        
    }
}
