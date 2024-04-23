using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TurretControl_t : MonoBehaviour
{
    public Image bossHealth;
    public GameObject bossHealthBar;
    public GameObject enemy;
    public GameObject player;
    public BallController pController;
    public GameObject beatBar;
    public GameObject aSpawner;
    private AmmoSpawn ammoSpawn;
    private bool start = false;
    private int perfectCnt;
    private int goodCnt;
    private int passCnt;

    // public BallController ballControl;
    public CanvasGroup perfectTextCanvasGroup;
    public CanvasGroup greatTextCanvasGroup;
    public CanvasGroup missingTextCanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        ammoSpawn = aSpawner.GetComponent<AmmoSpawn>();
        pController = player.GetComponent<BallController>();
    }

    public void addCnt(int type) 
    {
        if (type == 0) perfectCnt++;
        if (type == 1) goodCnt++;
        if (type == 2) passCnt++;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log("Boss:" + bossHealth.fillAmount);
        if (bossHealth.fillAmount == 0) {
            gameObject.SetActive(false);
            beatBar.SetActive(false);
            enemy.SetActive(false);
            pController.EnableMovement();
            // ballControl.EnableMovement();
            perfectTextCanvasGroup.alpha = 0;
            greatTextCanvasGroup.alpha = 0;
            missingTextCanvasGroup.alpha = 0;
            
        }
    }

    public void SpawnBullet(int t) {
        if (start)
        {
            ammoSpawn.Spawn(t);
        }
    }

    public void startFight()
    {
        // bossHealthBar.SetActive(true);
        start = true;
    }

    void OnDisable()
    {
        if (perfectCnt == 0 && goodCnt == 0 && passCnt == 0) return;
        string fileName = "analytics_perfect.txt";
        string content = string.Format("Perfect: {0}\nGood: {1}\nPass: {2}\n\n", perfectCnt, goodCnt, passCnt);
        File.AppendAllText(fileName, content);
    }
}
