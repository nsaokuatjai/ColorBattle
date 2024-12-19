using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack3 : EnemyAttackOriginal
{
    public GameObject game_object1;
    public GameObject game_object2;
    public GameObject game_object3; // 新しい攻撃オブジェクト
    private float time1 = 10;
    private float time2 = 10;
    private float time3 = 10; // 新しいタイマー
    public int attack_num1; // 攻撃回数1
    public int attack_num2; // 攻撃回数2
    public int attack_num3; // 攻撃回数3
    public float ctime1 = 5;
    public float ctime2 = 5;
    public float ctime3 = 30; // 新しいクールダウンタイム
    public Animator anime;
    public float atime1;
    public float atime2;
    public float atime3; // 新しいアニメーションタイマー

    public override void attack()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        time3 += Time.deltaTime; // 新しいタイマーの更新

        if (ctime1 < time1)
        {
            for (int i = 0; i < attack_num1; i++)
            {
                attack(game_object1, gameObject.transform.position);
            }
            time1 = 0;
            anime.SetBool("attack", true);
        }
        if (ctime1 - atime1 < time1)
        {
            anime.SetBool("attack", false);
        }

        if (ctime2 < time2)
        {
            for (int i = 0; i < attack_num2; i++)
            {
                attack(game_object2, gameObject.transform.position);
            }
            time2 = 0;
            anime.SetBool("attack", true);
        }
        if (ctime2 - atime2 < time2)
        {
            anime.SetBool("attack", false);
        }

        if (ctime3 < time3)
        {
            for (int i = 0; i < attack_num3; i++)
            {
                attack(game_object3, gameObject.transform.position);
            }
            time3 = 0;
            anime.SetBool("attack2", true);
        }
        if (ctime3 - atime3 < time3)
        {
            anime.SetBool("attack2", false);
        }
    }
}
