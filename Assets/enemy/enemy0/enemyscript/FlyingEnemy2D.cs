using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YourNamespace
{
    public class FlyingEnemy2D : EnemyMoveOriginal
    {
        private Rigidbody2D rb2d;
        public float targetHeight = 5f; // 敵キャラクターが維持する高さ
        public float heightAdjustSpeed = 2f; // 高さ調整の速度
        private bool movingRight = true; // 右方向に移動しているかどうかを示すフラグ
        public SpriteRenderer spriteRenderer; // キャラクターの絵を表示するためのSpriteRenderer
        private Transform playerTransform; // プレイヤーのTransform
        // 移動速度の宣言
        public float moveSpeed = 2f; // 移動速度
        private float originalMoveSpeed; // 元の移動速度を保存するための変数

        void Start()
        {
            playerTransform = player.transform; // プレイヤーのTransformを取得
            rb2d = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
            spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRendererコンポーネントを取得

            if (rb2d == null)
            {
                Debug.LogError("Rigidbody2D component is missing from this game object.");
            }
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing from this game object.");
            }
            if (player.transform == null)
            {
                Debug.LogError("Player transform is not assigned.");
            }

            originalMoveSpeed = moveSpeed; // 元の移動速度を保存
        }

        public override void moves()
        {
            if (rb2d != null)
            {
                // プレイヤーの位置を取得
                Vector2 playerPosition = player.transform.position;

                // プレイヤーの真上に移動するための目標位置を計算
                Vector2 targetPosition = new Vector2(playerPosition.x, targetHeight);

                // 現在の位置から目標位置への方向を計算
                Vector2 directionToTarget = (targetPosition - (Vector2)transform.position).normalized;

                // 目標位置に向かって移動する力を計算
                Vector2 desiredVelocity = directionToTarget * moveSpeed;

                // 水平速度の設定（垂直速度はそのまま維持）
                rb2d.velocity = new Vector2(desiredVelocity.x, rb2d.velocity.y);

                // 移動方向に応じてスプライトの向きを変える
                if (Mathf.Abs(desiredVelocity.x) > 0.1f) // 動いている場合のみ
                {
                    if (desiredVelocity.x > 0 && !movingRight)
                    {
                        movingRight = true;
                        FlipSprite();
                    }
                    else if (desiredVelocity.x < 0 && movingRight)
                    {
                        movingRight = false;
                        FlipSprite();
                    }
                }
            }
        }

        private void FlipSprite()
        {
            if (spriteRenderer != null)
            {
                // キャラクターの向きを反転
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 衝突したオブジェクトが障害物またはプレイヤーの場合
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Player"))
            {
                // 衝突点が下からの場合
                if (collision.contacts[0].normal.y > 0)
                {
                    // 上方向の力を無効にするため、垂直速度をゼロに設定
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                }
            }
        }
    }
}
