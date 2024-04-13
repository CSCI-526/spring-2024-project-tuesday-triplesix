using System.Collections;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationSpeed = 180f; // 每秒旋转的角度
    public float delayTime = 1f; // 延迟时间
    private float rotationTime = 0f;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool isRotating = true;

    void Start()
    {
        // 开始延迟后的旋转
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 180f);
    }

    void Update()
    {
        if (isRotating)
        {
            rotationTime += Time.deltaTime * rotationSpeed / 25f; // 根据旋转速度计算插值参数
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, rotationTime);
            if (rotationTime >= 1f)
            {
                isRotating = false;
                StartCoroutine(DelayedRotation());
                rotationTime = 0;
            }
        }
    }
    
    IEnumerator DelayedRotation()
    {
        // 等待一秒
        yield return new WaitForSeconds(delayTime);
        isRotating = true;
    }

    
}
