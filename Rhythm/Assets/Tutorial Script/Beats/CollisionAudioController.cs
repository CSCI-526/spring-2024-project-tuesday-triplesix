using UnityEngine;

public class CollisionAudioController : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the object you want
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("elevator");
            GameObject platform = platforms[0];
            Platform_t pfu = platform.GetComponent<Platform_t>();
            pfu.collision_();
            // Play audio from both audio sources
            Debug.Log("wow");
            if (audioSource1 != null)
            {
                audioSource1.Play();
            }
            if (audioSource2 != null)
            {
                audioSource2.Play();
            }
        }
    }
}
