using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public Button restartButtonLeft;
    public BossController bossControl;
    public BallController ballControl;
    public GameObject boss;
    public GameObject beatBar;
    public GameObject bSpawn;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public Button restartButton;
    public Button victoryButton;
    public Transform characterTransform;
    public float rayLength = 1f;
    public LayerMask detectLayer;

    public float flashDuration = 0.2f;
    public int flashCount = 2;

    private string obstacleTag = "Invisible";
    public float distanceThreshold = 30f;


    private Dictionary<GameObject, bool> obstacleStates = new Dictionary<GameObject, bool>();
    private int turretChoice;

    void Start()
    {
        Debug.Log("Start");
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        restartButtonLeft.onClick.AddListener(RestartGame);
        restartButton.onClick.AddListener(RestartGame);
        victoryButton.onClick.AddListener(RestartGame);
        bossControl = boss.GetComponent<BossController>();


        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);
        foreach (GameObject obstacle in obstacles)
        {
            obstacleStates.Add(obstacle, false);
        }

        turretChoice = 0;

    }

    void Update()
    {
        distanceThreshold = 30f;
        if (characterTransform.position.y < -17)
        {
            GameOver();
        }

        RaycastHit2D hit = Physics2D.Raycast(characterTransform.position, Vector2.right, rayLength, detectLayer);
        if (hit.collider != null)
        {
            Debug.Log("Hit " + hit.collider.name);
            GameOver();
        }

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);

        foreach (GameObject obstacle in obstacles)
        {

            float distance = Vector3.Distance(characterTransform.position, obstacle.transform.position);

            Transform obstacleTransform = obstacle.transform;

            BoxCollider2D obstacleCollider = obstacle.GetComponent<BoxCollider2D>();
            float obstacleWidth = obstacleCollider.size.x * obstacleTransform.localScale.x;

            if (distance < distanceThreshold && characterTransform.position.x < obstacle.transform.position.x + obstacleWidth)
            {
                if (obstacleStates.ContainsKey(obstacle) && obstacleStates[obstacle])
                    continue;
                Debug.Log("玩家和障碍物距离小于阈值！!!!!!!!!!!!!!!!!!!!!!!");
               
                StartCoroutine(FlashAndDisappear(obstacle));

            }
            else
            {
                Renderer obstacleRenderer = obstacle.GetComponent<Renderer>();
                if (obstacleRenderer != null)
                {
                    obstacleRenderer.enabled = true;
                }
            }

        }

        IEnumerator FlashAndDisappear(GameObject obstacle)
        {
            obstacleStates[obstacle] = true;
            Renderer obstacleRenderer = obstacle.GetComponent<Renderer>();

            if (obstacleRenderer == null)
            {
                yield break;
            }

            // 闪烁
            for (int i = 0; i < flashCount; i++)
            {
                obstacleRenderer.enabled = false;
                yield return new WaitForSeconds(flashDuration);
                obstacleRenderer.enabled = true;
                yield return new WaitForSeconds(flashDuration);
            }

            obstacleRenderer.enabled = false;

            Debug.Log("障碍物闪烁和消失完成！");
        }


        Debug.DrawRay(characterTransform.position, Vector2.right * rayLength, Color.red);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {   
        GameSetting.IsRestarting = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartBeat()
    {
        beatBar.SetActive(true);
        bossControl.autoMoveSpeed = 0f;
        ballControl.DisableMovement();
    }


    // void OnDestroy()
    // {
    //     Time.timeScale = 1f;

    //     restartButtonLeft.onClick.RemoveListener(RestartGame);
    //     restartButton.onClick.RemoveListener(RestartGame);
    // }
}
