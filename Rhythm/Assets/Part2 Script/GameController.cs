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

    public float fadeDuration = 2f;
    private float timer;

    public float flashDuration = 0.2f;
    public int flashCount = 2;
    public MusicController musicController;
    private string obstacleTag = "Invisible";
    public float distanceThreshold = 30f;
    public AudioSource Music2;
    public AudioSource Music1;
    public AudioSource MusicStart;
    private Dictionary<GameObject, bool> obstacleStates = new Dictionary<GameObject, bool>();
    private int turretChoice;
    private int currentMusic;
    public SceneController sceneController;

    void Start()
    {
        Debug.Log("Start");
        Time.timeScale = 1f;

        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        restartButtonLeft.onClick.AddListener(RestartGame);
        restartButton.onClick.AddListener(RestartGame);
        victoryButton.onClick.AddListener(BackToMenu);
        bossControl = boss.GetComponent<BossController>();
        currentMusic = 0;

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
        // sceneController.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        sceneController.LoadScene("Main Menu");
    }


    public void StartBeat()
    {
        /*AudioSource[] list = new AudioSource[] { MusicStart, Music1,Music2 };
        beatBar.SetActive(true);
        bossControl.autoMoveSpeed = 0f;
        ballControl.DisableMovement();
        float duration = 3f;
        Debug.Log(currentMusic);
        StartCoroutine(musicController.FadeOutCurrentMusicAndFadeInNewMusic(list[currentMusic], list[currentMusic + 1], duration));
        currentMusic = currentMusic + 1;
        */

        beatBar.SetActive(true);
        bossControl.autoMoveSpeed = 0f;
        ballControl.DisableMovement();
        PlayTurretMusic();

    }

    public void ChangeMusic() {
        AudioSource[] list = new AudioSource[] { MusicStart, Music1, MusicStart, Music2, MusicStart };
        //AudioSource[] list = new AudioSource[] { MusicStart, Music1, Music2 };
        float duration = 3f;
        StartCoroutine(musicController.FadeOutCurrentMusicAndFadeInNewMusic(list[currentMusic], list[currentMusic + 1], duration));
        currentMusic = currentMusic + 1;
    }

    public void PlayTurretMusic() {
        AudioSource[] list = new AudioSource[] {Music1, Music2 };
        float duration = 3f;
        // StartCoroutine(musicController.PlayNewMusic(MusicStart, list[currentMusic + 1], duration));
        StartCoroutine(musicController.FadeOutCurrentMusicAndFadeInNewMusic(MusicStart, list[currentMusic], duration));
        //StartCoroutine(musicController.PlayNewMusic(MusicStart, list[currentMusic], duration));
        currentMusic++;

    }
    public void ChangeBack() {
        StartCoroutine(ChangeBackCoroutine());
    }
    public IEnumerator ChangeBackCoroutine() {
        AudioSource[] list = new AudioSource[] { Music1, Music2 };
        AudioSource source = list[currentMusic - 1];
        float startFadeInVolume = MusicStart.volume;  // 通常这应该是0

        float startVolume = source.volume;
        float timer = 0f;

        while (source.volume > 0)
        {
            timer += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0f, timer / 2f);
            MusicStart.volume = Mathf.Lerp(startFadeInVolume, 0.3f, timer / 2f);
            Debug.Log("Volume: " + source.volume);
            if (source.volume <= 0.01f)  // 用一个小的阈值来确定何时停止
            {
                source.Stop();
                source.volume = 0;  // 确保音量设置为0
                break;
            }
            if (MusicStart.volume >= 0.29f)
            {
                MusicStart.volume = 0.3f;
                break;
            }
            yield return null;  // 等待下一帧
        }
        // list[currentMusic - 1].Stop();

        //list[currentMusic - 1].Stop();

        // StartCoroutine(musicController.IncrementV(MusicStart, 3f));
        

        /*float duration = 3f;
        float currentTime = 0;
        float startVolume = list[currentMusic].volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            list[currentMusic - 1].volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            list[currentMusic].volume = Mathf.Lerp(0, startVolume, currentTime / duration);
                       Debug.Log("New:" + newMusic.volume);
                        Debug.Log("Cur:" + currentMusic.volume);

        }
        MusicStart.volume = 30f;*/


    }


    // void OnDestroy()
    // {
    //     Time.timeScale = 1f;

    //     restartButtonLeft.onClick.RemoveListener(RestartGame);
    //     restartButton.onClick.RemoveListener(RestartGame);
    // }
}