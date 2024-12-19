using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyMoveOriginal
{
    public override void moves()
    {

            if (player == null) return;
            float directionToPlayer = player.transform.position.x - gameObject.transform.position.x;
            if(directionToPlayer > 0) enemy_anime.SetFloat("X", -1);
            else enemy_anime.SetFloat("X", 1);
            return;
    }
}
