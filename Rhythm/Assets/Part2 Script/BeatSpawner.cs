using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject upper;
    public GameObject lower;
    public GameObject boss;
    public GameObject beatBar;
    public GameObject turret;
    private BossController bossControl;

    public BallController ballControl;
    // in beats, 0 represents single beat, -1 represents choice part, positive number represents long beat
    private int[][] beats = new int[][] {
        new int[] {21,0,0,0,0,21,0,0,0,0},
        new int[] {0,5,20,0,0,35,0,0},
        new int[] {3,3,3}
    };
    private float[][] intervals = new float[][]{
        new float[] {0.65f,1.1f,0.5f,0.5f,0.5f,1.3f,1.15f,0.5f,0.5f,0.5f, 2.1f},
        new float[] {1f,1.3f,1.2f,1.75f,2.1f,2f,2.5f,2.9f},
        new float[] {0.03f,1f,1f}
    };
    private float timer;
    private int cnt = 0;
    private bool finish = false;
    private bool pathSelect = false;
    private bool endPart = false;
    private int path = -2;
    public GameObject single;
    public GameObject lasting;
    public GameObject choice;
    public CanvasGroup perfectTextCanvasGroup;
    public CanvasGroup greatTextCanvasGroup;
    public CanvasGroup missingTextCanvasGroup;
    void Start()
    {
        path = 0;
        Debug.Log("StartSpawner:" + path);
    }

    void SetLeftmost()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        GameObject ret = turrets[0];
        for (int i = 1; i < turrets.Length; i++) {
            GameObject cur = turrets[i];
            if (cur.transform.position.x < ret.transform.position.x) ret = cur;
        }
        turret = ret;
    }
    void OnEnable()
    {
        path += 1;
        cnt = 0;
        Debug.Log("Enable: " + path);
        finish = false;
        if (path >= 0) timer = intervals[path][cnt];
        single.SetActive(false);
        lasting.SetActive(false);
        choice.SetActive(false);
        bossControl = boss.GetComponent<BossController>();
        SetLeftmost();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !finish)
        {
            if (cnt < beats[path].Length) Spawn(beats[path][cnt]);
            else cnt += 1;
            if (cnt == intervals[path].Length) {
                finish = true;
                bossControl.autoMoveSpeed = 18f;
                turret.SetActive(false);
                beatBar.SetActive(false);
                ballControl.EnableMovement();
                perfectTextCanvasGroup.alpha = 0;
                greatTextCanvasGroup.alpha = 0;
                missingTextCanvasGroup.alpha = 0;
            }
            // Debug.Log("path: " + path);
            // Debug.Log("Cnt: " + cnt);
            if (!finish) timer = intervals[path][cnt]; // reset
        }

    }

    void Spawn(int cmd)
    {
        cnt += 1;
        if (cmd < 0) {
            Debug.Log("Spawn choice");
            GameObject choose = Instantiate(choice, transform.position, Quaternion.identity, transform);
            choose.SetActive(true);
        }
        if (cmd == 0) {
            GameObject circle = Instantiate(single, transform.position, Quaternion.identity, transform);
            circle.SetActive(true);
        } else {
            GameObject longBeat = Instantiate(lasting, transform.position, transform.rotation, transform);
            longBeat.transform.localScale = new Vector3(cmd, 1, 1);
            longBeat.SetActive(true);
        }
    }
}
