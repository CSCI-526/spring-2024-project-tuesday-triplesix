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
    private bool levelCompleted = false;

    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        
        currentScene = SceneManager.GetActiveScene();
        // Start the timer
        startTime = Time.time;
    }

    void Update()
    {
        // Update is called once per frame, check for level completion here
        if (CheckLevelCompleted()) // You need to implement this method
        {
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
    
        if (!levelCompleted)  // Check if the level has not been already completed
        {
            levelCompletionTime = Time.time - startTime;

            CustomEvent myEvent = new CustomEvent("LevelCompletionTime")
            {
                { "levelName", currentScene.name },
                { "completionTime", levelCompletionTime }
            };
            AnalyticsService.Instance.RecordEvent(myEvent);

            levelCompleted = true;  // Set to true to prevent multiple recordings
            // Optionally, you can load a new level or show a completion screen here
        }
    }
    
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ENDLINE"))
        {
            LevelCompleted(); 
        }
    }
}  
