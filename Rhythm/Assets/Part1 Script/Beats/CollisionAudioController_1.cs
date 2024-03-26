using UnityEngine;

public class CollisionAudioController_1 : MonoBehaviour
{



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
                Platform pfu = platform.GetComponent<Platform>();
                pfu.collision_();
            }
        }
    }
}
