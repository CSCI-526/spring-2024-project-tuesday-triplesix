using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    void Start()
    {
    }

    


    public IEnumerator FadeOutCurrentMusicAndFadeInNewMusic(AudioSource currentMusic, AudioSource newMusic, float duration)
    {
        float currentTime = 0;
        float startVolume = currentMusic.volume;

        newMusic.Play();
        newMusic.volume = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            currentMusic.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            newMusic.volume = Mathf.Lerp(0, startVolume, currentTime / duration);
/*            Debug.Log("New:" + newMusic.volume);
            Debug.Log("Cur:" + currentMusic.volume);*/
            yield return null;
        }

        currentMusic.Stop();
    }

    public IEnumerator FadeOutNewMusicAndFadeInCurrentMusic(AudioSource currentMusic, AudioSource newMusic, float duration)
    {
        float currentTime = 0;
        float startVolume = newMusic.volume;

        currentMusic.Play();
        currentMusic.volume = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            newMusic.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            currentMusic.volume = Mathf.Lerp(0, startVolume, currentTime / duration);
            yield return null;
        }

        newMusic.Stop();
    }
}
