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

    void Start()
    {
        Debug.Log("Start");
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        restartButtonLeft.onClick.AddListener(RestartGame);
        restartButton.onClick.AddListener(RestartGame);
        victoryButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
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

    void OnDestroy()
    {
        Time.timeScale = 1f;

        restartButtonLeft.onClick.RemoveListener(RestartGame);
        restartButton.onClick.RemoveListener(RestartGame);
    }
}
