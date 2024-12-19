using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBounce : EnemyMoveOriginal
{
    public float downwardForce = -5f; // 下方向の力
    public float upwardForce = 5f;    // 上方向の力
    public float bounceInterval = 1f; // バウンド間隔
    public float moveSpeed = 2f; // 一定の移動速度
    public float maintainDistance = 3f; // プレイヤーから保つ距離

    private Transform playerTransform; // プレイヤーのTransform
    private Rigidbody2D rd;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        playerTransform = player.transform; // プレイヤーのTransformを取得

        if (rd == null)
        {
            rd = GetComponent<Rigidbody2D>();
        }

        StartCoroutine(BounceRoutine());
    }

    IEnumerator BounceRoutine()
    {
        while (true)
        {
            // 下方向の力を加える
            if (rd != null)
            {
                rd.AddForce(new Vector2(0, downwardForce), ForceMode2D.Impulse);
            }

            // 少し待つ
            yield return new WaitForSeconds(bounceInterval);

            // movesメソッドを呼び出して、一定距離を保ちながらプレイヤーを追いかける
            moves();

            // 上方向の力を加える
            if (rd != null)
            {
                rd.AddForce(new Vector2(0, upwardForce), ForceMode2D.Impulse);
            }

            // 次のバウンドまで待つ
            yield return new WaitForSeconds(bounceInterval);

            // movesメソッドを呼び出して、一定距離を保ちながらプレイヤーを追いかける
            moves();
        }
    }

    public override void moves()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer > maintainDistance)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                direction.y = 0; // 上方向には力を与えない

                rd.velocity = new Vector2(direction.x * moveSpeed, rd.velocity.y); // 一定の速さでプレイヤーを追いかける

                // 向きを変える処理を追加（動きを変えずに向きのみ）
                if (playerTransform.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z); // 左向き
                }
                else
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // 右向き
                }
            }
            else
            {
                // プレイヤーに近づきすぎている場合、横方向の速度をリセットする
                rd.velocity = new Vector2(0, rd.velocity.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁に衝突した場合、横方向の速度をリセットして落下させる
        if (collision.gameObject.CompareTag("field"))
        {
            rd.velocity = new Vector2(0, rd.velocity.y);
        }
    }
}
