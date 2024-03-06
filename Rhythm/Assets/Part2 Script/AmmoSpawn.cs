using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawn : MonoBehaviour
{
    public GameObject ammo1;
    public GameObject ammo2;
    public GameObject ammo3;
    // Start is called before the first frame update
    void Start()
    {
        ammo1.SetActive(false);
        ammo2.SetActive(false);
        ammo3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(int t) {
        if (t == 0) {
            GameObject bigAmmo = Instantiate(ammo1, transform.position, Quaternion.identity, transform);
            bigAmmo.SetActive(true);
        } else if (t == 1) {
            GameObject midAmmo = Instantiate(ammo2, transform.position, Quaternion.identity, transform);
            midAmmo.SetActive(true);
        } else {
            GameObject smlAmmo = Instantiate(ammo3, transform.position, Quaternion.identity, transform);
            smlAmmo.SetActive(true);
        }
    }
}
