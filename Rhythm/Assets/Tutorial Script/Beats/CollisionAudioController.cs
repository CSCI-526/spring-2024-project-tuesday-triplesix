using UnityEngine;

public class CollisionAudioController : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;


    private bool playerOnBoxAndPressedE = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the object you want
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set the flag indicating the player is on the box
            playerOnBoxAndPressedE = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision with the player ends
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the flag when the player leaves the box
            playerOnBoxAndPressedE = false;
        }
    }

    private void Update()
    {
        // Check if the player is on the box and pressed "E"
        if (playerOnBoxAndPressedE && Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("elevator");
            if (platforms.Length > 0)
            {
                GameObject platform = platforms[0];
                Platform_t pfu = platform.GetComponent<Platform_t>();
                pfu.collision_();

                // Play audio from both audio sources
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
}
