using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball; // 球的Transform
    public float followThreshold = 0.33f; // 开始跟随的阈值，表示当球移动到视角的右侧1/3位置时
    public Vector3 offset; // 摄像机相对于球的偏移量
    private bool shouldFollow = false; // 标记是否应该开始跟随
    private bool offsetCalculated = false; // 标记是否已经计算过偏移量

    void Start()
    {
        // 初始化时，只计算y轴的偏移量
        offset.y = Camera.main.transform.position.y - ball.position.y;
    }

    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(ball.position);

        if (viewportPos.x > followThreshold && !shouldFollow)
        {
            shouldFollow = true;
            if (!offsetCalculated)
            {
                offset.x = Camera.main.transform.position.x - ball.position.x;
                offsetCalculated = true; // 确保偏移量只计算一次
            }
        }

        if (shouldFollow)
        {
            transform.position = ball.position + offset;
        }
    }

}
