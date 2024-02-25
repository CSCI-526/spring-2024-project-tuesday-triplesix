using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeatControl : MonoBehaviour
{
    public GameObject circle;
    public TextMeshProUGUI scoreText;
    public bool updateScore = false;
    private float perfect = 0.5f;
    private float good = 1.0f;
    private float pass = 1.5f;
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
            if (updateScore) sc.score += 100;
            return 0;
        }
        else if (distance <= good) {
            if (updateScore) sc.score += 30;
            return 1;
        }
        else if (distance <= pass) {
            if (updateScore) sc.score += 10;
            return 2;
        }
        else {
            if (updateScore) sc.score -= 30;
            return 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 10;
        if (gameObject.CompareTag("Single") && Input.GetButtonDown("Jump")){
            distance = GetAbs(transform.position.x - circle.transform.position.x);
            int status = GetStatus(distance);
            Debug.Log("Jump: " + status);
            if (status < 3) gameObject.SetActive(false);
        } else if (gameObject.CompareTag("Long") && Input.GetButtonDown("Fire1")){
            distance = GetAbs(transform.position.x - (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            Debug.Log("Begin shrink: " + status);
        } else if (gameObject.CompareTag("Long") && Input.GetButtonUp("Fire1")) {
            distance = GetAbs(transform.position.x + (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            Debug.Log("After shrink: " + status);
            if (status < 3) gameObject.SetActive(false);
        }
        
    }
}
