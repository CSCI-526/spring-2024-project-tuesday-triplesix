using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFollow : MonoBehaviour
{
    public GameObject mainCam;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - mainCam.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = mainCam.transform.position + offset;
    }
}
