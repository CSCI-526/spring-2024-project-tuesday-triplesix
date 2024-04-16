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
    public Button Level2Button;
    public Button Level3Button;
    public Button BossLevelButton;
    public SceneController sceneController;
    public Button close;
    public void Start()
    {
        Time.timeScale = 1f;
        playButton.onClick.AddListener(LevelSelection);
        Level1Button.onClick.AddListener(level1);
        Level2Button.onClick.AddListener(level2);
        Level3Button.onClick.AddListener(level3);
        BossLevelButton.onClick.AddListener(level4);
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
    public void level1()
    {
        sceneController.LoadScene("Level1");
    }
    public void level2()
    {
        sceneController.LoadScene("Level2");
    }
    public void level3()
    {
        sceneController.LoadScene("Level3");
    }
    public void level4()
    {
        sceneController.LoadScene("BossFight");
    }
    public void PlayTutorial()
    {
        sceneController.LoadScene("Tutorial");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
     
