using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float followSpeed = 2.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Transform PlayerTransform;
    private Vector2 targetPosition;
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;//提前在外面把Player标签给对象挂上
        transform.position = PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(PlayerTransform != null)
        {
            targetPosition.x = Mathf.Clamp(PlayerTransform.position.x,minX,maxX);
            targetPosition.y = Mathf.Clamp(PlayerTransform.position.y,minY,maxY);
            transform.position = Vector2.Lerp(PlayerTransform.position,targetPosition,followSpeed*Time.deltaTime);
        }
    }
}