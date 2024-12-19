using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTree : EnemyMoveOriginal
{
    private Rigidbody2D rb;
    public float jumpForce = 10f; // ジャンプ力
    public float jumpCooldown = 2f; // ジャンプのクールダウン時間
    private float jumpCooldownTimer = 0f; // ジャンプのクールダウンタイマー
    public float minDistance = 3f; // プレイヤーとの最小距離

    void Start()
    {
        move_speed = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    public override void moves()
    {
        if (jumpCooldownTimer > 0)
        {
            jumpCooldownTimer -= Time.deltaTime;
        }

        if (player != null)
        {
            Transform playerTransform = player.transform; // プレイヤーのTransformを取得
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            float distance = Vector2.Distance(playerTransform.position, transform.position); // プレイヤーとの距離を計算

            if (distance > minDistance)
            {
                // プレイヤーが最小距離よりも遠い場合
                // プレイヤーに向かって移動
                rb.velocity = new Vector2(direction.x * move_speed, rb.velocity.y);
            }
            else
            {
                // プレイヤーが最小距離以内の場合
                // プレイヤーから離れるように移動
                rb.velocity = new Vector2(-direction.x * move_speed, rb.velocity.y);
            }

            // プレイヤーの方向を向く処理（向きを逆に）
            if ((direction.x > 0 && transform.localScale.x > 0) || (direction.x < 0 && transform.localScale.x < 0))
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }

            // ジャンプ処理
            if (jumpCooldownTimer <= 0)
            {
                Jump();
                jumpCooldownTimer = jumpCooldown;
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
