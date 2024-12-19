using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveS : EnemyMoveOriginal
{
    private Rigidbody2D rb;
    public float jumpForce = 10f; // ジャンプ力
    public float jumpCooldown = 2f; // ジャンプのクールダウン時間
    private float jumpCooldownTimer = 0f; // ジャンプのクールダウンタイマー
    public float minDistance = 3f; // プレイヤーから保つ最小距離
    private bool isBlocked = false; // 障害物にブロックされたかどうか

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
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer > minDistance && !isBlocked)
            {
                direction.y = 0; // 上方向には力を与えない

                // 一定の速度でプレイヤーを追いかける
                rb.velocity = new Vector2(direction.x * move_speed, rb.velocity.y);

                // プレイヤーの方向を向く処理
                if ((direction.x > 0 && transform.localScale.x < 0) || (direction.x < 0 && transform.localScale.x > 0))
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
            else
            {
                // プレイヤーに近づきすぎた場合、または障害物にブロックされた場合、移動を停止する
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("field"))
        {
            // 障害物に当たったときの処理
            isBlocked = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("field"))
        {
            // 障害物から離れたときの処理
            isBlocked = false;
        }
    }
}
