using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TurretControl : MonoBehaviour
{
    public Image bossHealth;
    public GameObject beatBar;
    public GameObject aSpawner;
    private AmmoSpawn ammoSpawn;
    private int perfectCnt;
    private int goodCnt;
    private int passCnt;

    public BallController ballControl;
    public CanvasGroup perfectTextCanvasGroup;
    public CanvasGroup greatTextCanvasGroup;
    public CanvasGroup missingTextCanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        ammoSpawn = aSpawner.GetComponent<AmmoSpawn>();
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
        if (bossHealth.fillAmount == 0) {
            gameObject.SetActive(false);
            beatBar.SetActive(false);
            ballControl.EnableMovement();
            perfectTextCanvasGroup.alpha = 0;
            greatTextCanvasGroup.alpha = 0;
            missingTextCanvasGroup.alpha = 0;
        }
    }

    public void SpawnBullet(int t) {
        ammoSpawn.Spawn(t);
    }

    void OnDisable()
    {
        if (perfectCnt == 0 && goodCnt == 0 && passCnt == 0) return;
        string fileName = "analytics_perfect.txt";
        string content = string.Format("Perfect: {0}\nGood: {1}\nPass: {2}\n\n", perfectCnt, goodCnt, passCnt);
        File.AppendAllText(fileName, content);
    }
}
