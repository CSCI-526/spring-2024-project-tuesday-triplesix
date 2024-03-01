using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BeatControl : MonoBehaviour
{
    public GameObject circle;
    public TextMeshProUGUI scoreText;
    public bool updateScore = false;
    public Image bossHealth;
    private float perfect = 0.5f;
    private float good = 1.0f;
    private float pass = 1.5f;
    private float health;
    private ScoreController sc;
    // Start is called before the first frame update

    void Start()
    {
        sc = scoreText.GetComponent<ScoreController>();
    }
    float GetAbs(float tar) 
    {
        if (tar <= 0) return -tar;
        else return tar;
    }

    int GetStatus(float distance)
    {
        if (distance <= perfect) {
            if (updateScore) health -= 0.3f;
            return 0;
        }
        else if (distance <= good) {
            if (updateScore) health -= 0.15f;
            return 1;
        }
        else if (distance <= pass) {
            if (updateScore) health -= 0.1f;
            return 2;
        }
        else {
            return 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = bossHealth.fillAmount;
        float distance = 10;
        if (gameObject.CompareTag("Single") && Input.GetButtonDown("Jump")){
            distance = GetAbs(transform.position.x - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("Jump: " + status);
            if (status < 3) gameObject.SetActive(false);
        } else if (gameObject.CompareTag("Long") && Input.GetButtonDown("Fire1")){
            distance = GetAbs(transform.position.x - (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("Begin shrink: " + status);
        } else if (gameObject.CompareTag("Long") && Input.GetButtonUp("Fire1")) {
            distance = GetAbs(transform.position.x + (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("After shrink: " + status);
            if (status < 3) gameObject.SetActive(false);
        }

        bossHealth.fillAmount = Math.Max(health, 0);
    }
}
