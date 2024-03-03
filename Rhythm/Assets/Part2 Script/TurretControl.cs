using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretControl : MonoBehaviour
{
    public Image bossHealth;
    public GameObject beatBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (bossHealth.fillAmount == 0) {
            gameObject.SetActive(false);
            beatBar.SetActive(false);
        }
    }
}
