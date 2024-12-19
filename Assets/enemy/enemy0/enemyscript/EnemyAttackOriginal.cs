using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackOriginal : MonoBehaviour
{
    protected GameObject player;
    public void setPlayer(GameObject obj) { player = obj; }
    //具体的な攻撃方法を書く
    //敵のゲームオブジェクトに直接アタッチするのでgameObject.Transform.positionで座標を取得できる
    public abstract void attack();
    //ゲームオブジェクトを生成(攻撃を出す)メソッド
    protected void attack(GameObject gameObject,Vector3 position)
    {
        Instantiate<GameObject>(gameObject, position, Quaternion.identity);
    }
}
