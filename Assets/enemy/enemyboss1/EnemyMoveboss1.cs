using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyMoveboss1 : EnemyMoveOriginal
{
    Vector2 moves_vector=new Vector2(0,0);
    Vector2 moves_vector_y = new Vector2(0, 0);
    public float def_move;
    public float max_speed;
    public float bairitu_speed;
    private float muki;
    int direction = 0;
    int direction_y = 0;
    private Vector3 scale;
    public bool attack_time=false;
    public bool dontmove = false;
    float y_position;
    void Start()
    {
        scale = gameObject.transform.localScale;
        y_position= gameObject.transform.position.y;
    }
    public override void moves()
    {
     
            if (player == null) return;
            float directionToPlayer = player.transform.position.x - gameObject.transform.position.x;
        float directionPoint = gameObject.transform.position.y - y_position;
         if (directionToPlayer > 0&& !(attack_time)) enemy_anime.SetFloat("X", -1);
         else if(!(attack_time))enemy_anime.SetFloat("X", 1);
        muki = direction;
        if (directionToPlayer < 0) direction = -1;
        else direction = 1;
        //if (directionPoint > 0.2) direction_y = 1;
        //else if (directionPoint < -0.2) direction_y = -1;
        //else direction_y = 0;
        moves_vector_y.y = directionPoint;
        moves_vector.x= direction;
        if ( !(attack_time)) {
            scale.x=-1*direction* UnityEngine.Mathf.Abs(scale.x) ;
            gameObject.transform.localScale = scale;
                }
        float distanceToPlayer = Mathf.Abs(directionToPlayer)/ def_move;
        if (max_speed < UnityEngine.Mathf.Abs(rd.velocity.x)|| dontmove) distanceToPlayer = 0;
         rd.AddForce((moves_vector* distanceToPlayer * move_speed- rd.velocity)* bairitu_speed, ForceMode2D.Force);
        rd.AddForce(moves_vector_y/10);
        return;
    }
}
