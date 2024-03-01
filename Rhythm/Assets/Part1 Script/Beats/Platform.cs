using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private UI UIObject;
    public float movementSpeed = 50.0f;
    private Vector3 originalPosition;
    private float timer = 0f;
    private Renderer objRenderer;
    private Color originalColor;
    private void Start()
    {
        UIObject = FindObjectOfType<UI>();
        Debug.Log(UIObject);
        originalPosition = transform.position;
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;

    }

    void Update()
    {
        // Check if the player is on the elevator
        if (UIObject.moving)
        {
            // Move the elevator upward
            if (transform.position.y >= originalPosition.y + 10)
            {
                UIObject.beat = false;
                UIObject.count = 0;
                UIObject.pkey = 1;
                UIObject.moving = false;
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    timer = 0f;
                    UIObject.moving = true;
                }
            }
            else
            {
                if (timer == 0f)
                {
                    transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

                }
   
            }
        }
        else if(transform.position.y > originalPosition.y && timer==0f)
        {
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        }

        if (UIObject.color)
        {
            ChangeObjectColor(Color.red);
        }
        else
        {
            ChangeObjectColor(originalColor);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {

            //UIObject.gameObject.SetActive(true);
            if(timer == 0f)
            {
                UIObject.beat = true;
            }
        }

    }
    void ChangeObjectColor(Color newColor)
    {
        // objRenderer.material.color = newColor;
        objRenderer.material = new Material(objRenderer.material);
        objRenderer.material.color = newColor;
    }

    void ChangeColorBack()
    {
        // Use the originalColor variable to revert the color
        ChangeObjectColor(originalColor);
    }

    //private void OnTriggerExit2D(Collider2D collider2D)
    //{
    //    if (collider2D.CompareTag("Player"))
    //    {

    //        //UIObject.gameObject.SetActive(true);
    //        UIObject.beat = false;
    //        UIObject.count = 0;
    //        UIObject.pkey = true;
    //        UIObject.moving = false;
    //        Debug.Log("not");
    //    }
    //}

}