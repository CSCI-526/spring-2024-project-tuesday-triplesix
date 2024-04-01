using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToMain : MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D collision)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    // 碰撞到特定对象后返回主页面
                    SceneManager.LoadScene("Main Menu");
                }
            }
}
