using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectionController : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup perfectTextCanvasGroup;
    public CanvasGroup greatTextCanvasGroup;
    public CanvasGroup normalTextCanvasGroup;
    private Coroutine currentFadeCoroutine;
    public void ShowStatusText(int status)
    {   
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
            ResetCanvasGroupsAlpha();
        }
        switch (status)
        {
            case 0:
                currentFadeCoroutine = StartCoroutine(FadeText(perfectTextCanvasGroup, true));
                break;
            case 1:
                currentFadeCoroutine = StartCoroutine(FadeText(greatTextCanvasGroup, true));
                break;
            case 2:
                currentFadeCoroutine = StartCoroutine(FadeText(normalTextCanvasGroup, true));
                break;
        }
    }
    private IEnumerator FadeText(CanvasGroup canvasGroup, bool fadeIn, float duration = 0.3f)
    {
        float counter = 0f;
        float startAlpha = fadeIn ? 0f : canvasGroup.alpha;
        float endAlpha = fadeIn ? 1f : 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / duration);
            yield return null;
        }

        if (fadeIn)
        {
            yield return new WaitForSeconds(0f);
            StartCoroutine(FadeText(canvasGroup, false, 0.3f));
        }
    }
    private void ResetCanvasGroupsAlpha()
    {
        perfectTextCanvasGroup.alpha = 0f;
        greatTextCanvasGroup.alpha = 0f;
        normalTextCanvasGroup.alpha = 0f;
    }
}
