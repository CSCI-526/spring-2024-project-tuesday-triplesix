using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretControl : MonoBehaviour
{
    public Image bossHealth;
    public GameObject beatBar;
    public GameObject aSpawner;
    private AmmoSpawn ammoSpawn;

    public BallController ballControl;
    // Start is called before the first frame update
    void Start()
    {
        ammoSpawn = aSpawner.GetComponent<AmmoSpawn>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (bossHealth.fillAmount == 0) {
            gameObject.SetActive(false);
            beatBar.SetActive(false);
            ballControl.EnableMovement();
        }
    }

    public void SpawnBullet(int t) {
        ammoSpawn.Spawn(t);
    }
}
