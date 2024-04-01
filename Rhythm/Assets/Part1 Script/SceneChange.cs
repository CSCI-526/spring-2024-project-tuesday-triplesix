using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneController sceneController;
    private bool isFading = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -40 && !isFading) {
            sceneController.LoadScene("Part2 Scene");
            isFading = true;
            // SceneManager.LoadScene("Part2 Scene");
        }
    }
}
