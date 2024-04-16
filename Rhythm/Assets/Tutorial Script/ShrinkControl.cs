using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrinkControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 squareScale = new Vector3(1, 1, 1);
    private Vector3 originalScale;
    public GameObject beatsBar;
    public Image healthBar;
    public GameObject player;
    public BallController pController;
    void Start()
    {
        healthBar.enabled = false;
        originalScale = transform.localScale;
        pController = player.GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Turret"))
        {
            Debug.Log("touch turret");
            ShowBeatsBar();
            healthBar.enabled = true;
            pController.DisableMovement();
        }
    }

    public void ShowBeatsBar()
    {
        if (beatsBar != null)
        {
            // Try to find the renderer in the children
            Renderer[] renderers = beatsBar.GetComponentsInChildren<Renderer>(true);

            if (renderers.Length > 0)
            {
                foreach (Renderer renderer in renderers)
                {
                    renderer.enabled = true;
                }
            }
            else
            {
                Debug.LogError("Renderer component not found in the children of beatsBar GameObject.");
            }
            GameObject[] beats = GameObject.FindGameObjectsWithTag("Beat");
            GameObject beat = beats[0];
            BeatSpawner_t b = beat.GetComponent<BeatSpawner_t>();
            b.beat_start();
        }
        else
        {
            Debug.LogError("beatsBar GameObject not assigned.");
        }
    }

}
