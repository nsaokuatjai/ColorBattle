using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : EnemyAttackOriginal
{
    public GameObject game_object;
    public GameObject game_object2;
    private float time1 = 10;
    private float time2 = 10;
    public int attack_num1; // 攻撃回数1
    public int attack_num2; // 攻撃回数2
    public float ctime1 = 5;
    public float ctime2 = 7;
    public Animator anime;
    public float atime1;
    public float atime2;

    public override void attack()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;

        if (ctime1 < time1)
        {
            for (int i = 0; i < attack_num1; i++)
            {
                attack(game_object, gameObject.transform.position);
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
    }
}
