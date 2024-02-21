using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject upper;
    public GameObject lower;
    // in beats, 0 represents single beat, -1 represents choice part, positive number represents long beat
    private int[][] beats = new int[][] {
        new int[] {0,10,0,15,-1},
        new int[] {0,0,0,6,0,5,0,0},
        new int[] {0,5,20,0,0,35,0,0},
        new int[] {3,3,3}
    };
    private float[][] intervals = new float[][]{
        new float[] {0.03f, 2.5f,1.8f,2.7f,1.7f},
        new float[] {0.01f,0.9f,1.2f,0.95f,1.1f,1.3f,2.1f,2.2f},
        new float[] {1f,1.3f,1.2f,1.75f,2.1f,2f,2.5f,2.9f},
        new float[] {0.03f,1f,1f}
    };
    private float timer;
    private int cnt = 0;
    private bool finish = false;
    private bool pathSelect = false;
    private bool endPart = false;
    private int path = 0;
    public GameObject single;
    public GameObject lasting;
    public GameObject choice;

    void Start()
    {
        timer = intervals[path][cnt];
        single.SetActive(false);
        lasting.SetActive(false);
        choice.SetActive(false);
    }

    void Update() {
        if (ball.transform.position[0] > 75 && !pathSelect){
            if (ball.transform.position[1] > 0) {
                path = 1;
                lower.SetActive(false);
            }
            else {
                path = 2;
                upper.SetActive(false);
            }
            cnt = 0;
            finish = false;
            pathSelect = true;
        }
        if (ball.transform.position[0] > 226.97 && !endPart) {
            path = 3;
            cnt = 0;
            finish = false;
            endPart = true;
        }
        
        Debug.Log(path);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !finish)
        {
            Spawn(beats[path][cnt]);
            if (cnt == beats[path].Length) {
                finish = true;
            }
            timer = intervals[path][cnt]; // reset
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
