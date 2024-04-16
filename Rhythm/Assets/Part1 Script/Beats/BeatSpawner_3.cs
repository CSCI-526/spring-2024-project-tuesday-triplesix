using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner_3 : MonoBehaviour
{
    public GameObject ball;
    public GameObject upper;
    public GameObject lower;
    public GameObject boss;
    public GameObject beatBar;
    private GameObject turret;
    private BossController bossControl;

    // in beats, 0 represents single beat, -1 represents choice part, positive number represents long beat
    private int[][] beats = new int[][] {
        new int[] {0,0,0,6,0,5,0,0},
        new int[] {0,5,20,0,0,35,0,0},
        new int[] {3,3,3}
    };
    private float[][] intervals = new float[][]{
        new float[] {0.01f,0.9f,1.2f,0.95f,1.1f,1.3f,2.1f,2.2f},
        new float[] {1f,1.3f,1.2f,1.75f,2.1f,2f,2.5f,2.9f},
        new float[] {0.03f,1f,1f}
    };
    // private float timer;
    // private float timer_2;
    private int cnt = 0;
    private bool finish = false;
    private bool pathSelect = false;
    private bool endPart = false;
    private int path = -2;
    public GameObject single;
    public GameObject lasting;
    public GameObject choice;

    private float bpm = 128.0f;
    private float beatInterval; // 每拍的时间间隔
    private float timer; // 时间累计
    private int beatCount = 1; // 拍数计数器

    private List<int> spawnBeats = new List<int> {3, 5, 6, 7}; // 需要触发Spawn的拍数

    void Start()
    {
        path = 0;
        Debug.Log("StartSpawner:" + path);
    }

    void SetLeftmost()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("elevator");
        GameObject ret = turrets[0];
        for (int i = 1; i < turrets.Length; i++) {
            GameObject cur = turrets[i];
            if (cur.transform.position.x < ret.transform.position.x) ret = cur;
        }
        turret = ret;
    }
    void OnEnable()
    {
        // path += 1;
        // cnt = 0;
        // Debug.Log("Enable: " + path);
        // finish = false;
        // timer = 0.70f;
        // timer_2 = timer + 0.55f;
        timer = 0f;
        beatCount = 0;
        finish = false;
        beatInterval = 60f / bpm;
        single.SetActive(false);
        lasting.SetActive(false);
        choice.SetActive(false);
        //bossControl = boss.GetComponent<BossController>();
        //SetLeftmost();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= beatInterval)
        {
            timer -= beatInterval;
            beatCount++;
            
            // 如果beatCount在需要触发Spawn的拍数中，调用Spawn(0)
            if (spawnBeats.Contains(beatCount))
            {
                Spawn(0);
            }

            // 每8拍重置beatCount
            if (beatCount >= 8)
            {
                beatCount = 0;
            }
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
