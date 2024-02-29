using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampoPlatform : MonoBehaviour
{
    public float springForce = 10f; // 弹簧力大小

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检测到玩家角色碰撞
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                // 施加向上的力
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f); // 先将垂直速度清零
                playerRigidbody.AddForce(Vector2.up * springForce, ForceMode2D.Impulse);
            }
        }
    }
}
