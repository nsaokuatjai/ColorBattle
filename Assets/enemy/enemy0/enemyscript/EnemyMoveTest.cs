using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTest : EnemyMoveOriginal
{
    private Rigidbody2D rb; // 2Dの物理エンジンを扱うためのRigidbody2Dコンポーネント
    private Transform playerTransform; // プレイヤーのTransformを保持する変数
    public float slowDownDistance = 5f; // スピードを下げ始める距離
    public float minimumSpeedFactor = 0.2f; // 最小速度の割合（基本速度の何倍か）

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform; // タグが"Player"のゲームオブジェクトのTransformを取得
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found");
        }
    }

    public override void moves()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            direction.y = 0; // 上方向には力を与えない

            // プレイヤーとの距離を計算
            float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

            // 距離に基づいてスピードを調整
            float speedFactor = Mathf.Lerp(minimumSpeedFactor, 1.0f, distanceToPlayer / slowDownDistance);
            float adjustedSpeed = move_speed * speedFactor;

          // Debug.Log($"Moving towards player with speed: {adjustedSpeed}, direction: {direction}");

            rb.AddForce(direction * adjustedSpeed);

            // 方向に応じて回転（X軸だけ）
            if (direction.x != 0)
            {
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x) * Mathf.Sign(direction.x), transform.localScale.y);
            }
        }
        else
        {
            Debug.LogError("Player transform is null");
        }
    }
}
