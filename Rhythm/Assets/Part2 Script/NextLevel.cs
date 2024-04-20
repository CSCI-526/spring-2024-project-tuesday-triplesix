using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Button nextLevelButton;
    public SceneController sceneController;

    void Start()
    {   
        nextLevelButton.onClick.AddListener(NextLevelScene);
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("当前场景名称: " + sceneName);
    }

    // Update is called once per frame
    public void NextLevelScene()
    {
        Time.timeScale = 1f;
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Tutorial1")
        {   

            sceneController.LoadScene("Tutorial2");
        }
        else if (sceneName == "Tutorial2")
        {
            sceneController.LoadScene("Tutorial3");
        }
        else if (sceneName == "Tutorial3")
        {
            sceneController.LoadScene("Level1");
        }
        else if (sceneName == "Level1")
        {   
            Debug.Log("Level1!!!!!");
            sceneController.LoadScene("Level2");
        }
        else if (sceneName == "Level2")
        {
            sceneController.LoadScene("Level3");
        }
        else if (sceneName == "Level3")
        {
            sceneController.LoadScene("Boss Fight");
        }
        else if (sceneName == "Boss Fight")
        {
            sceneController.LoadScene("MainMenu");
        }
    }
}
