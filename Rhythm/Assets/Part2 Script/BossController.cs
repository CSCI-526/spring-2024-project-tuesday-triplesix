using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject boss;
    public Image health;
    public GameObject healthBar;
    private Rigidbody2D bossrb;
    public float autoMoveSpeed = 20.0f;
    public GameController gameController;
    void Start()
    {
        bossrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bossrb.velocity = new Vector2(autoMoveSpeed, 0);
        // Debug.Log("Health:" + health.fillAmount);
        if (health.fillAmount == 0) {
            boss.SetActive(false);
            healthBar.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the Boss. Game Over.");
            gameController.GameOver();
        }
    }

}
