using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject boss;
    private Rigidbody2D bossrb;
    public float autoMoveSpeed = 20.0f;
    void Start()
    {
        bossrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bossrb.velocity = new Vector2(autoMoveSpeed, 1);


    }

}
