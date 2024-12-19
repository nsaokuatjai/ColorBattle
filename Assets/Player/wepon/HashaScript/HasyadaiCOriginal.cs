using System;
using System.Diagnostics;
using UnityEngine;

public  class HasyadaiCOriginal : MonoBehaviour
{
    //管理用に追加
    [NonSerialized]
    public HasydaiManager hasydai_manager;
    //発射台の攻撃力の倍率
    public float hasyadai_power;
    //打ち出す花火
    [NonSerialized]
    public GameObject[] hanabi;
    //打ち出す花火
    public GameObject[] hasydai;
    //装備に必要な花火の数
    public int equipment_hanabi_num;
    //破壊するかを確認するフラグ
    protected bool isRmain=false;
    //発射する数を管理
    public int attack_num;
    public int attack_loop_num;
    //クールタイム
    public float ctime;
    //発射間隔を管理
    public float attack_rate;
    //発射台を管理する数
    [NonSerialized]
    public int id_sikibetu;


    // プレイヤーのゲームオブジェクト
    private GameObject player;

    public virtual void attack(int id)
    {
        if (player == null) return;
        //GameObject obj = Instantiate<GameObject>(hasydai[id], this.transform.position, Quaternion.identity);
        GameObject obj = Instantiate<GameObject>(hasydai[id], player.transform.position, Quaternion.identity);
        HasyadaiOriginal script= obj.GetComponent<HasyadaiOriginal>();
        if(script != null )
        {
            script.hasyadai_power = hasyadai_power;
            script.hasydai_manager = hasydai_manager;
            script.equipment_hanabi_num = equipment_hanabi_num;
            script.id_sikibetu = id_sikibetu;
        }
    }
    public virtual void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }
}