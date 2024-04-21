using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningController : MonoBehaviour
{
    public GameObject boss;
    public BossController bossController;
    public GameObject player;
    public BallController ballController;
    public GameObject staticMsg;
    public float scaleTime = 1.0f;  // 放大和缩小的持续时间
    public float maxScale = 1.5f;   // 最大放大倍数
    public float minScale = 1.0f;   // 最小缩小倍数
    private RectTransform rectTransform;
    private float timer;
    private float stopTime = 3f;
    private bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Warning start");
        rectTransform = GetComponent<RectTransform>();  // 获取RectTransform组件
        StartCoroutine(BlinkEffect());
        bossController = boss.GetComponent<BossController>();
        bossController.autoMoveSpeed = 0f;
        ballController = player.GetComponent<BallController>();
        ballController.DisableMovement();
    }

    IEnumerator BlinkEffect()
    {
        Vector3 originalScale = rectTransform.localScale;  // 获取原始大小
        while (true)
        {
            // 放大
            LeanTween.scale(rectTransform, originalScale * maxScale, scaleTime).setEaseInOutSine();
            yield return new WaitForSeconds(scaleTime);
            // 缩小
            LeanTween.scale(rectTransform, originalScale * minScale, scaleTime).setEaseInOutSine();
            yield return new WaitForSeconds(scaleTime);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (!stopped && timer > stopTime) {
            stopped = true;
            gameObject.SetActive(false);
            staticMsg.SetActive(false);
            bossController.autoMoveSpeed = 12.0f;
            ballController.EnableMovement();
        }
    }
}
