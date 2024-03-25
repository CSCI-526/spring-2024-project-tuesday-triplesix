using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BeatControl : MonoBehaviour
{
    public GameObject circle;
    public GameObject turret;
    public GameObject beatSpawner;
    public TextMeshProUGUI scoreText;
    public bool updateScore = false;
    public Image bossHealth;
    private float perfect = 0.2f;
    private float good = 0.5f;
    private float pass = 1f;
    private float health;
    private ScoreController sc;
    private BeatSpawner bSpawn;
    private TurretControl tControl;
    // Start is called before the first frame update

    void Start()
    {
        sc = scoreText.GetComponent<ScoreController>();
        bSpawn = beatSpawner.GetComponent<BeatSpawner>();
        turret = bSpawn.turret;
        tControl = turret.GetComponent<TurretControl>();
    }
    float GetAbs(float tar) 
    {
        if (tar <= 0) return -tar;
        else return tar;
    }

    int GetStatus(float distance)
    {
        Debug.Log("B");
        if (distance <= perfect) {
            if (updateScore) tControl.SpawnBullet(0);
            return 0;
        }
        else if (distance <= good) {
            if (updateScore) tControl.SpawnBullet(1);
            return 1;
        }
        else if (distance <= pass) {
            if (updateScore) tControl.SpawnBullet(2);
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
        if (gameObject.CompareTag("Single") && Input.GetKeyDown(KeyCode.J)){
            distance = GetAbs(transform.position.x - circle.transform.position.x);
            // Debug.Log("dist:" + distance);
            int status = GetStatus(distance);
            Debug.Log(health);
            // Debug.Log("Jump: " + status);
            if (status < 3) gameObject.SetActive(false);
        } else if (gameObject.CompareTag("Long") && Input.GetKeyDown(KeyCode.J)){
            distance = GetAbs(transform.position.x - (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("Begin shrink: " + status);
        } else if (gameObject.CompareTag("Long") && Input.GetKeyUp(KeyCode.J)) {
            distance = GetAbs(transform.position.x + (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("After shrink: " + status);
            if (status < 3) gameObject.SetActive(false);
        }
        // Debug.Log("health: " + health);
        bossHealth.fillAmount = Math.Max(health, 0);
    }
}
