using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Core;
using Unity.Services.Analytics;


public class ObstablesCollider : MonoBehaviour
{
    private Scene currentScene;
    private Rigidbody2D rb;
    private int value = 0;

    async void Start()
    {
        await UnityServices.InitializeAsync();
        rb = GetComponent<Rigidbody2D>();
        AnalyticsService.Instance.StartDataCollection();
        currentScene = SceneManager.GetActiveScene();
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("collide");
            Vector2 spawnPoint = GameManager.Instance.respawnPoint;
            value += 1;
            rb.transform.position = spawnPoint;
        }
    }
    
    private void OnDestroy()
    {

        if (currentScene.name == "Level1")
        {
            CustomEvent myEvent = new CustomEvent("Level1DeathTimes")
                { { "times", value } };
            AnalyticsService.Instance.RecordEvent(myEvent);
        }
        else if (currentScene.name == "Level2")
        {        
            Debug.Log(currentScene.name);
            Debug.Log(value);
            CustomEvent myEvent = new CustomEvent("Level2DeathTimes")
                { { "times", value } };
            AnalyticsService.Instance.RecordEvent(myEvent);
        }
        else if (currentScene.name == "Level3")
        {
            CustomEvent myEvent = new CustomEvent("Level3DeathTimes")
                { { "times", value } };
            AnalyticsService.Instance.RecordEvent(myEvent);
        }
        
        // File.AppendAllText(fileName, content);
    }

}