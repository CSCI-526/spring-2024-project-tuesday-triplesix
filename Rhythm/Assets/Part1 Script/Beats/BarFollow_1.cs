using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFollow_1 : MonoBehaviour
{
    public GameObject mainCam;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(4.44f, 2.98f, 1.5f);
        // Debug.Log("offset:" + offset);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = mainCam.transform.position + offset;
    }
}
