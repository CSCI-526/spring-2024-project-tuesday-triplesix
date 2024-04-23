using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {   
        Debug.Log("Back to Menu");
        GameController.alreadyRestarted = false;
        SceneManager.LoadScene("Main Menu");
    }
}
