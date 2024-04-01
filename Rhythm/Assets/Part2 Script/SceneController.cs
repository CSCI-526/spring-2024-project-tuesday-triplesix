using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;

    private void Awake()
    
    {
        fadeGroup.alpha = 1;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(Fade(0));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        yield return Fade(1);

        SceneManager.LoadScene(sceneName);

        yield return Fade(0);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float speed = Mathf.Abs(fadeGroup.alpha - targetAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeGroup.alpha, targetAlpha))
        {
            fadeGroup.alpha = Mathf.MoveTowards(fadeGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
    }
}
