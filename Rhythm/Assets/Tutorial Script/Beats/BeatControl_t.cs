using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BeatControl_t : MonoBehaviour
{
    public GameObject circle;
    public GameObject player;
    public GameObject ammoSpawner;
    public AmmoSpawn aSpawn;
    public TextMeshProUGUI scoreText;
    public bool updateScore = false;
    private float perfect = 0.5f;
    private float good = 1.0f;
    private float pass = 1.5f;
    private float health = 5;
    private ScoreController_1 sc;
    public CanvasGroup perfectTextCanvasGroup;
    public CanvasGroup greatTextCanvasGroup;
    public CanvasGroup normalTextCanvasGroup;
    public PerfectionController pc;
    // Start is called before the first frame update

    void Start()
    {
        sc = scoreText.GetComponent<ScoreController_1>();
        aSpawn = ammoSpawner.GetComponent<AmmoSpawn>();
    }
    float GetAbs(float tar) 
    {
        if (tar <= 0) return -tar;
        else return tar;
    }

    int GetStatus(float distance)
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("elevator");
        GameObject platform = platforms[0];
        Platform_t pfu = platform.GetComponent<Platform_t>();

        Debug.Log("player:" + player.transform.position.x);
        if (distance <= perfect) {
            if (player.transform.position.x > 91) {
                Debug.Log("Spawn");
                aSpawn.Spawn(0);
            }
            else pfu.allowMove();
            pc.ShowStatusText(0);
            return 0;
        }
        else if (distance <= good) {
            if (player.transform.position.x > 91) {
                Debug.Log("Spawn");
                aSpawn.Spawn(1);
            }
            else pfu.allowMove();
            //platform.MoveUpCoroutine();
            pc.ShowStatusText(1);
            return 1;
        }
        else if (distance <= pass) {
            if (player.transform.position.x > 91) {
                Debug.Log("Spawn");
                aSpawn.Spawn(2);
            }
            else pfu.allowMove();
            //platform.MoveUpCoroutine();
            pc.ShowStatusText(2);
            return 2;
        }
        else {
            return 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
