using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneController sceneController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -40) {
            sceneController.LoadScene("Part2 Scene");
            // SceneManager.LoadScene("Part2 Scene");
        }
    }
}
