using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private AudioSource[] audioSources;
    public float drumVolume;
    public float verseVolume;
    private void Start()
    {
        // 获取所有AudioSource组件
        audioSources = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        // 当对象碰撞时，随机选择一个音频源播放音频
        if (collider2D.CompareTag("Player"))
        {
            audioSources[0].volume = verseVolume;
            audioSources[1].volume = drumVolume;
        }
    }
}
