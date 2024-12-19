using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMoveOriginal : MonoBehaviour
{
    protected GameObject player;
    public void setPlayer(GameObject obj) { player = obj; }
    public Animator enemy_anime; // 敵キャラクターのAnimatorを指定
    public float move_speed;
    public abstract void moves();
    public Rigidbody2D rd;
}
