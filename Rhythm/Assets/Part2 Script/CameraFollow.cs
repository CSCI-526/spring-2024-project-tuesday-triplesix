using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball; // 球的Transform
    public Vector3 offset; // 摄像机相对于球的偏移量

    void Update()
    {
        // 设置摄像机的位置为球的位置加上偏移量
        transform.position = ball.position + offset;
    }
}
