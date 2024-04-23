using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.Services.Core;
using Unity.Services.Analytics;



public class BeatControl : MonoBehaviour
{
    public GameObject circle;
    public GameObject turret;
    public GameObject beatSpawner;
    public TextMeshProUGUI scoreText;
    public bool updateScore = false;
    public Image bossHealth;
    private float perfect = 0.4f;
    private float good = 0.8f;
    private float pass = 1.5f;
    private int perfectCnt = 0;
    private int goodCnt = 0;
    private int passCnt = 0;
    private float health;
    private ScoreController sc;
    private BeatSpawner bSpawn;
    private TurretControl tControl;
    // Start is called before the first frame update
    public CanvasGroup perfectTextCanvasGroup;
    public CanvasGroup greatTextCanvasGroup;
    public CanvasGroup normalTextCanvasGroup;
    public PerfectionController pc;
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
    // public void ShowStatusText(int status)
    // {
    //     switch (status)
    //     {
    //         case 0:
    //             StartCoroutine(FadeText(perfectTextCanvasGroup, true));
    //             break;
    //         case 1:
    //             StartCoroutine(FadeText(greatTextCanvasGroup, true));
    //             break;
    //         case 2:
    //             StartCoroutine(FadeText(normalTextCanvasGroup, true));
    //             break;
    //     }
    // }
    // private IEnumerator FadeText(CanvasGroup canvasGroup, bool fadeIn, float duration = 0.5f)
    // {
    //     float counter = 0f;
    //     float startAlpha = fadeIn ? 0f : canvasGroup.alpha;
    //     float endAlpha = fadeIn ? 0.5f : 0f;

    //     while (counter < duration)
    //     {
    //         counter += Time.deltaTime;
    //         canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / duration);
    //         yield return null;
    //     }

    //     if (fadeIn)
    //     {
    //         yield return new WaitForSeconds(0f);
    //         StartCoroutine(FadeText(canvasGroup, false, 0.5f));
    //     }
    // }
    int GetStatus(float distance)
    {
     
        if (distance <= perfect)
        {
            if (updateScore) tControl.SpawnBullet(0);
            tControl.addCnt(0);
            pc.ShowStatusText(0);
            return 0;
        }
        else if (distance <= good)
        {
            if (updateScore) tControl.SpawnBullet(1);
            tControl.addCnt(1);
            pc.ShowStatusText(1);
            return 1;
        }
        else if (distance <= pass)
        {
            if (updateScore) tControl.SpawnBullet(2);
            tControl.addCnt(2);
            pc.ShowStatusText(2);
            return 2;
        }
        else
        {

            return 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = bossHealth.fillAmount;
        float distance = 10;
        if (gameObject.CompareTag("Single") && Input.GetKeyDown(KeyCode.J))
        {
            distance = GetAbs(transform.position.x - circle.transform.position.x);
            // Debug.Log("dist:" + distance);
            int status = GetStatus(distance);
            //Debug.Log(health);
            // Debug.Log("Jump: " + status);
            if (status < 3) gameObject.SetActive(false);
        }
        else if (gameObject.CompareTag("Long") && Input.GetKeyDown(KeyCode.J))
        {
            distance = GetAbs(transform.position.x - (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("Begin shrink: " + status);
        }
        else if (gameObject.CompareTag("Long") && Input.GetKeyUp(KeyCode.J))
        {
            distance = GetAbs(transform.position.x + (transform.localScale.x / 2) - circle.transform.position.x);
            int status = GetStatus(distance);
            // Debug.Log("After shrink: " + status);
            if (status < 3) gameObject.SetActive(false);
        }
        // Debug.Log("health: " + health);
        bossHealth.fillAmount = Math.Max(health, 0);
    }

    // void OnDisable()
    // {
    //     // Debug.Log("disabled");
    //     // string fileName = "analytics.txt";
    //     string content = string.Format("Perfect: {0}\nGood: {1}\nPass: {2}\n", perfectCnt, goodCnt, passCnt);
    //     Debug.Log("content: " + content);
    //     CustomEvent myEvent = new CustomEvent("PerfectCount")
    //     {
    //         { "perfect", perfectCnt},
    //         { "good", goodCnt },
    //         { "normal", passCnt }
    //     };
    //     // AnalyticsResult analyticsResult = Analytics.CustomEvent(
    //     //     "Perfect count",
    //     //     new Dictionary<string, object> {
    //     //         {"Perfect", perfectCnt},
    //     //         {"Good", goodCnt},
    //     //         {"Normal", passCnt}
    //     //     }
    //     // );
    //     AnalyticsService.Instance.RecordEvent(myEvent);
    //     // File.WriteAllText(fileName, content);
    // }
}