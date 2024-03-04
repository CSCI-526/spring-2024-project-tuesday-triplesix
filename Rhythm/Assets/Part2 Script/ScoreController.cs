using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    GameObject GetLeftmost()
    {
        GameObject[] single = GameObject.FindGameObjectsWithTag("Single");
        GameObject[] longBeat = GameObject.FindGameObjectsWithTag("Long");
        GameObject[] beats = new GameObject[single.Length + longBeat.Length];
        single.CopyTo(beats, 0);
        longBeat.CopyTo(beats, single.Length);

        if (beats.Length == 0) return null;
        GameObject ret = beats[0];
        for (int i = 1; i < beats.Length; i++) {
            GameObject cur = beats[i];
            if (cur.transform.position.x < ret.transform.position.x) ret = cur;
        }
        return ret;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject effective = GetLeftmost();
        if (effective != null) {
            effective.GetComponent<BeatControl_1>().updateScore = true;
        }
        // scoreText.text = "Score: " + score.ToString();
    }
}
