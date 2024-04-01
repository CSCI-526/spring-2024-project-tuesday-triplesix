using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public GameObject LevelPanel;
    public Button Level1Button;
    public SceneController sceneController;
    public Button close;
    public void Start()
    {
        Time.timeScale = 1f;
        playButton.onClick.AddListener(LevelSelection);
        Level1Button.onClick.AddListener(Play);
        close.onClick.AddListener(Close);
    }
    public void LevelSelection()
    {   
        LevelPanel.SetActive(true);

    }
    public void Close()
    {
        LevelPanel.SetActive(false);
    }
    public void Play()
    {
        // SceneManager.LoadScene("Part1 Scence");
        sceneController.LoadScene("Part1 Scence");
    }
    public void PlayTutorial()
    {
        // SceneManager.LoadSceneAsync(1);
        sceneController.LoadScene("Tutorial");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
     
