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
    public void Start()
    {
        playButton.onClick.AddListener(LevelSelection);
        Level1Button.onClick.AddListener(Play);
    }
    public void LevelSelection()
    {   
        LevelPanel.SetActive(true);

    }
    public void Play()
    {
        SceneManager.LoadScene("Part1 Scence");
    }
    public void PlayTutorial()
    {
        SceneManager.LoadSceneAsync(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
     
