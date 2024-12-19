using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemyAttackOriginal
{
    public GameObject bulletPrefab;
    public float ctime; // 攻撃間隔（クールタイム）
    private float nextAttackTime; // 次の攻撃可能な時間

    void Start()
    {
        // 最初の攻撃時間を設定する
        nextAttackTime = Time.time + ctime;
    }

    void Update()
    {
        // 攻撃間隔の経過を確認し、攻撃が可能ならば攻撃する
        if (Time.time >= nextAttackTime)
        {
            attack();
            nextAttackTime = Time.time + ctime;
        }
    }

    public override void attack()
    {
        // bulletPrefab が null の場合は攻撃を行わない
        if (bulletPrefab != null)
        {
            // 弾丸を敵の位置から生成する
            Vector2 spawnPosition = transform.position;
            attack(bulletPrefab, spawnPosition);
        }
        else
        {
            Debug.LogError("bulletPrefab is null. Attack cannot be executed.");
        }
    }
}
