using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private UI UIObject;

    private void Start()
    {
        UIObject = FindObjectOfType<UI>();
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            UIObject.gameObject.SetActive(true);
        }
    }
}
