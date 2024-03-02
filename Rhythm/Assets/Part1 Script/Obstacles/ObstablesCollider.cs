using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstablesCollider : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = GameManager.Instance.respawnPoint;
        }
    }

}
