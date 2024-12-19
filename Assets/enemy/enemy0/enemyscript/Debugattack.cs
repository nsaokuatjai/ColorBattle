using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Debugattack : MonoBehaviour
{
    protected GameObject player;
    public GameObject obj;
    public void setPlayer(GameObject obj) { player = obj; }
    public Vector3 po;
    //具体的な攻撃方法を書く
    //敵のゲームオブジェクトに直接アタッチするのでgameObject.Transform.positionで座標を取得できる
  void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            attack(obj, gameObject.transform.position+po);
        }
        if (Input.GetKey(KeyCode.M))
        {
            Destroy(gameObject);
        }
    }
    //ゲームオブジェクトを生成(攻撃を出す)メソッド
    protected void attack(GameObject gameObject,Vector3 position)
    {
        Instantiate<GameObject>(gameObject, position, Quaternion.identity);
    }
}
