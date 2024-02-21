using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerr : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset = new Vector3(8f,-2f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset; 
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}