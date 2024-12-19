using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacePlayer : EnemyMoveOriginal
{
    private Transform player;

    void Start()
    {
        // プレイヤーのTransformを取得（タグ "Player" を持つオブジェクトを探す）
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void moves()
    {
        if (player != null)
        {
            Transform playerTransform = player.transform; // プレイヤーのTransformを取得
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            // プレイヤーの方向を向く処理（向きを逆に）
            if ((direction.x > 0 && transform.localScale.x < 0) || (direction.x < 0 && transform.localScale.x > 0))
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            }
        }
    }
}
