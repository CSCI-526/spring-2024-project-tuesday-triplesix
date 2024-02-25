using UnityEngine;
using TMPro;

public class GameInitializer : MonoBehaviour
{
    public GameObject player; // 玩家对象
    public Transform cameraTarget; // 相机最终要移动到的目标位置
    public float cameraMoveSpeed = 20.0f; // 相机移动的速度
    private Vector3 initialCameraPosition; // 相机的初始位置
    public CameraFollow cameraFollowScript; // 引用 CameraFollow 脚本
    public GameObject beatBar;
    public TextMeshProUGUI scoreText;
    public float targetOrthographicSize = 25f; // 目标正交大小
    private float initialOrthographicSize; // 初始正交大小
    void Start()
    {
        initialOrthographicSize = Camera.main.orthographicSize;
        beatBar.SetActive(false);
        scoreText.enabled = false;
        initialCameraPosition = Camera.main.transform.position;
        // 暂时禁用 CameraFollow 脚本
        Time.timeScale = 0f;
        if (cameraFollowScript != null) 
        {
            cameraFollowScript.enabled = false;
        }
        // 开始相机移动的协程
        StartCoroutine(MoveCameraToTarget(cameraTarget.position, () => {
            // 相机移动结束后的回调
            StartCoroutine(MoveCameraBack(initialCameraPosition, () => {
                // 相机移动回到初始位置后的回调
                ResumeGame();
            }));
        }));
    }

    System.Collections.IEnumerator MoveCameraToTarget(Vector3 targetPosition, System.Action onCompleted = null)
    {
        float startTime = Time.unscaledTime;
        
        float journeyLength = Vector3.Distance(Camera.main.transform.position, targetPosition);
        float journey = 0f;
        while (Vector3.Distance(Camera.main.transform.position, new Vector3(targetPosition.x, targetPosition.y, initialCameraPosition.z)) > 0.01f)
        {
            float distCovered = (Time.unscaledTime - startTime) * cameraMoveSpeed;
            journey = distCovered / journeyLength;
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(targetPosition.x, targetPosition.y, initialCameraPosition.z), cameraMoveSpeed * Time.unscaledDeltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(initialOrthographicSize, targetOrthographicSize, journey); // 动态调整正交大小

            yield return null;
        }

        yield return new WaitForSecondsRealtime(2);
        onCompleted?.Invoke();
    }
    System.Collections.IEnumerator MoveCameraBack(Vector3 targetPosition, System.Action onCompleted = null)
    {   
        float startTime = Time.unscaledTime;
        float journeyLength = Vector3.Distance(Camera.main.transform.position, targetPosition);
        float journey = 0f;
        while (Vector3.Distance(Camera.main.transform.position, new Vector3(targetPosition.x, targetPosition.y, initialCameraPosition.z)) > 0.01f)
        {
            float distCovered = (Time.unscaledTime - startTime) * 120;
            journey = distCovered / journeyLength;
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(targetPosition.x, targetPosition.y, initialCameraPosition.z), 120 * Time.unscaledDeltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(targetOrthographicSize, initialOrthographicSize, journey); // 动态调整正交大小

            yield return null;
        }
        yield return new WaitForSecondsRealtime(2);
        onCompleted?.Invoke();
    }
    void ResumeGame()
    {
        // 恢复游戏时间
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        beatBar.SetActive(true);
        scoreText.enabled = true;
        Camera.main.orthographicSize = initialOrthographicSize;

        // 启用 CameraFollow 脚本
        if (cameraFollowScript != null)
        {
            cameraFollowScript.enabled = true;
        }
        // 这里可以添加其他恢复游戏的逻辑
    }

}