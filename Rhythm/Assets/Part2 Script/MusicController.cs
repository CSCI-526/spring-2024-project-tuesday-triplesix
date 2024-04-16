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

    public IEnumerator PlayNewMusic(AudioSource currentMusic, AudioSource newMusic, float fadeDuration)
    {
        yield return StartCoroutine(FadeOutCurrentMusic(currentMusic,fadeDuration));
        yield return StartCoroutine(PlayNewMusicCoroutine(newMusic, fadeDuration));
    }

    // ???????????0
    private IEnumerator FadeOutCurrentMusic(AudioSource currentMusic, float fadeDuration)
    {
        float startVolume = currentMusic.volume;

        while (currentMusic.volume > 0)
        {
            currentMusic.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        currentMusic.volume = 0; // ??????0???????
    }

    // ?????
    private IEnumerator PlayNewMusicCoroutine(AudioSource newMusic, float fadeDuration)
    {
        yield return new WaitForSeconds(fadeDuration); // ???????????

        //musicSource.clip = newMusic;
        newMusic.Play();

        // ???????????????????????????
    }
}
