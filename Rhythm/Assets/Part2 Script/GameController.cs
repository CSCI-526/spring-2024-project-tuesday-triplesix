using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button restartButtonLeft; // 在Inspector中设置这个按钮
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public Button restartButton; // 在Inspector中设置这个按钮
    public Button victoryButton;
    public Transform characterTransform; // 方块的 Transform 组件
    public float rayLength = 1f; // 射线检测的长度
    public LayerMask detectLayer; // 射线检测的层

    public float flashDuration = 0.2f; // 闪烁时间
    public int flashCount = 2; // 闪烁次数

    public string obstacleTag = "Obstacle";  // 障碍物的标签
    public float distanceThreshold = 30f;  // 距离阈值，可以根据需要调整


    private Dictionary<GameObject, bool> obstacleStates = new Dictionary<GameObject, bool>();

    void Start()
    {
        Debug.Log("Start");
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        restartButtonLeft.onClick.AddListener(RestartGame);
        restartButton.onClick.AddListener(RestartGame);
        victoryButton.onClick.AddListener(RestartGame);


        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);
        foreach (GameObject obstacle in obstacles)
        {
            obstacleStates.Add(obstacle, false);
        }
    }

    void Update()
    {
        distanceThreshold = 30f;
        // 检测方块是否掉到某个位置以下
        if (characterTransform.position.y < -17) // 假设游戏结束的条件是方块的y坐标小于-7
        {
            GameOver();
        }

        // 使用 Raycasting 检测方块右侧是否碰到物体
        RaycastHit2D hit = Physics2D.Raycast(characterTransform.position, Vector2.right, rayLength, detectLayer);
        if (hit.collider != null)
        {
            // 如果检测到碰撞，触发游戏结束逻辑
            Debug.Log("Hit " + hit.collider.name);
            GameOver();
        }

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);

        // 遍历每个障碍物对象
        foreach (GameObject obstacle in obstacles)
        {


            // 计算玩家和当前障碍物之间的距离
            float distance = Vector3.Distance(characterTransform.position, obstacle.transform.position);

            Transform obstacleTransform = obstacle.transform;

            // 获取障碍物的BoxCollider2D组件
            BoxCollider2D obstacleCollider = obstacle.GetComponent<BoxCollider2D>();
            float obstacleWidth = obstacleCollider.size.x * obstacleTransform.localScale.x;

            // 判断距离是否小于阈值
            if (distance < distanceThreshold && characterTransform.position.x < obstacle.transform.position.x + obstacleWidth)
            {
                if (obstacleStates.ContainsKey(obstacle) && obstacleStates[obstacle])
                    continue;
                // 如果距离小于阈值，执行你想要的操作，例如显示提示、触发事件等
                Debug.Log("玩家和障碍物距离小于阈值！!!!!!!!!!!!!!!!!!!!!!!");
                /*Renderer obstacleRenderer = obstacle.GetComponent<Renderer>();
                if (obstacleRenderer != null)
                {
                    obstacleRenderer.enabled = false;
                    Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                }
                */
                StartCoroutine(FlashAndDisappear(obstacle));



                //StartCoroutine(FlashAndDisappear(obstacle));
            }
            else
            {
                // 如果距离大于等于阈值，确保障碍物可见
                Renderer obstacleRenderer = obstacle.GetComponent<Renderer>();
                if (obstacleRenderer != null)
                {
                    obstacleRenderer.enabled = true;
                }
            }



            //Debug.Log("Distance: " + distance + obstacleStates[obstacle]);

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

            // 障碍物消失
            obstacleRenderer.enabled = false;

            // 记录障碍物已经消失过


            // 在这里可以执行其他操作，如果需要
            Debug.Log("障碍物闪烁和消失完成！");
        }


        // 可视化射线（仅在 Scene 视图中可见，对游戏运行无影响）
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
        Time.timeScale = 1f; // 重置时间速度
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // void OnDestroy()
    // {
    //     Time.timeScale = 1f;

    //     restartButtonLeft.onClick.RemoveListener(RestartGame);
    //     restartButton.onClick.RemoveListener(RestartGame);
    // }
}
