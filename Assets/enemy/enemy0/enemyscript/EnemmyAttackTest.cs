using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacktTest : EnemyAttackOriginal
{
    public GameObject projectilePrefab; // 攻撃で生成するプレハブ
    private float attackCooldown = 3.0f; // 攻撃のクールダウン時間
    private float timeSinceLastAttack = 0.0f; // 最後の攻撃からの経過時間
    public override void attack()
{
    timeSinceLastAttack += Time.deltaTime;
    if (timeSinceLastAttack >= attackCooldown)
    {
        Vector3 spawnPosition = transform.position + transform.forward * 1.5f;
        attack(projectilePrefab, spawnPosition);

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            projectilePrefab.transform.forward = direction;
        }

        timeSinceLastAttack = 0.0f; // クールダウン時間をリセット
    }
}
}