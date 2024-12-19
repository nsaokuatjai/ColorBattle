using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : EnemyAttackOriginal
{
    public GameObject game_object;
    private float time=10;
    public int attack_num;
    public float ctime=5;
    public Animator anime;
    public float atime;
    public override void attack()
    {
        time += Time.deltaTime;
        if(ctime<time)
        {
            for (int i=0; i < attack_num; i++)
            {
                attack(game_object, gameObject.transform.position);
              
            }
            time = 0;
            anime.SetBool("attack",true);
        }
        if(ctime-atime < time)
        {
            anime.SetBool("attack",false);
        }
           
    }
}
