using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    public float followThreshold = 0.33f;
    public Vector3 offset; 
    private bool shouldFollow = false;
    private bool offsetCalculated = false;

    void Start()
    {
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
                offsetCalculated = true;
            }
        }

        if (shouldFollow)
        {
            transform.position = ball.position + offset;
        }
    }

}
