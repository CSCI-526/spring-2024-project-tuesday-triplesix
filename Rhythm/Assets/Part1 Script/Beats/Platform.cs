using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private UI UIObject;
    public float movementSpeed = 2.0f;
    private Vector3 originalPosition;
    private void Start()
    {
        UIObject = FindObjectOfType<UI>();
        Debug.Log(UIObject);
        originalPosition = transform.position;

    }

    void Update()
    {
        // Check if the player is on the elevator
        if (UIObject.moving)
        {
            // Move the elevator upward
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }
        //else if(transform.position.y > originalPosition.y)
        //{
        //    transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {

            //UIObject.gameObject.SetActive(true);
            UIObject.beat = true;
        }

    }


    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {

            //UIObject.gameObject.SetActive(true);
            UIObject.beat = false;
            UIObject.count = 0;
            UIObject.pkey = true;
            UIObject.moving = false;
        }

    }

}