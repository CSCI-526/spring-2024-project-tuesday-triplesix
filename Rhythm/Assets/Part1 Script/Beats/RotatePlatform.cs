using System.Collections;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationSpeed = 30f; 
    private Rigidbody2D rb;
    private Vector2 centerPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        centerPosition = rb.position;
        StartCoroutine(PlatformRoutine());
    }

    private IEnumerator PlatformRoutine()
    {
        while (true)
        {
            // TODO: how to make it rotate smoothly?
            transform.Rotate(Vector3.forward, 90f);
            yield return new WaitForSeconds(1f); // wait
        }
    }
}
