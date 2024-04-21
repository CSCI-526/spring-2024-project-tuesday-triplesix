using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class LevelCompletionTracker : MonoBehaviour
{
    private Scene currentScene;
    private float startTime;
    private float levelCompletionTime;

    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        currentScene = SceneManager.GetActiveScene();
        // Start the timer
        startTime = Time.time;
    }

    private void LevelCompleted()
    {
        levelCompletionTime = Time.time - startTime;
        
        CustomEvent myEvent = new CustomEvent("LevelCompletionTime")
        {
            { "levelid", currentScene.name },
            { "completionTime", levelCompletionTime }
        };
        AnalyticsService.Instance.RecordEvent(myEvent);
    }
    
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ENDLINE"))
        {
            LevelCompleted(); 
        }
    }
}  
