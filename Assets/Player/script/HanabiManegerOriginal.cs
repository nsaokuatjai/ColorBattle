using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanabiManegerOriginal : MonoBehaviour
{   //管理用に追加
    [System.NonSerialized]
    public HasydaiManager hasydai_manager;
    //発射台の攻撃力の倍率
    [System.NonSerialized]
    public float hasyadai_power;
    //花火の攻撃力の倍率
    public float hanabi_power;
    //装備可能な弾の数を表示
    public int equipment_tama_num;
    //装備する弾の数を管理
    [System.NonSerialized]
    public int[] tama_num;
    //弾を管理する数
    [System.NonSerialized]
    public TamaOriginal tama;
    public GameObject[] hanabi;
    //発射する数を管理
    public int attack_num;
    //発射する回数を管理
    public int attack_loop_num;
    //発射間隔を管理
    public float attack_rate;
    //弾を管理する数
    public int id_hanabi;
    //発射台を管理する数
    [NonSerialized]
    public int id_sikibetu;
    [NonSerialized]
    public int id_sikibetu_Tama;

    //ほんとに使うtama
    private Tama[][] eq_tama;


    protected System.Random random;
    protected void Start()
    {

        random = new System.Random((int)DateTime.Now.Ticks);
        if (hasydai_manager.debug)
        {
            if (id_sikibetu == 0)
            {

                tama_num = hasydai_manager.tama_num;
                tama = hasydai_manager.tama;
            }
            if (id_sikibetu == 1)
            {
                tama_num = hasydai_manager.tama_num2;
                tama = hasydai_manager.tama;
            }
        }
        else
        {
            if (id_sikibetu == 0)
            {

                eq_tama = hasydai_manager.Tama_obj0;
            }
            if (id_sikibetu == 1)
            {
                eq_tama= hasydai_manager.Tama_obj1;
            }
        }
    }
    
    public void attack(int id, int tama_num)
    {
        for (int i = 0; i < attack_num; i++)
        {
    
            if (eq_tama != null) if (eq_tama[id_sikibetu_Tama][tama_num] == null) return;

            GameObject obj = Instantiate<GameObject>(hanabi[id], this.transform.position, Quaternion.identity);
            AttackOriginal attack_script = obj.GetComponent<AttackOriginal>();
         //   UnityEngine.Debug.Log("hasyadai_power" + hasyadai_power);
           // UnityEngine.Debug.Log("hanabi_power" + hanabi_power);
            if (hasyadai_power == null) UnityEngine.Debug.Log("hasypowererr");
            if (hanabi_power == null) UnityEngine.Debug.Log("hanabi_power");
            if (attack_script == null) UnityEngine.Debug.Log("vattack_script");
            attack_script.power = hasyadai_power * hanabi_power;
            if (hasydai_manager.debug)
            {
                if (tama.tama[tama_num].abi.Length != 0)
                {
                    if (tama.tama[tama_num].abi[0] == 1)
                    {
                        byte randomByte_r = GetRandomByte(150, 255);
                        byte randomByte_g = GetRandomByte(150, 255);
                        byte randomByte_b = GetRandomByte(150, 255);
                        attack_script.r = randomByte_r;
                        attack_script.b = randomByte_g;
                        attack_script.g = randomByte_b;

                    }
                }

                attack_script.r = tama.tama[tama_num].r;
                attack_script.b = tama.tama[tama_num].b;
                attack_script.g = tama.tama[tama_num].g;


            }
            else
            {
                if (eq_tama[id_sikibetu_Tama][tama_num] == null) continue;
                if (eq_tama[id_sikibetu_Tama][tama_num].abi.Length != 0)
                {
                    if (eq_tama[id_sikibetu_Tama][tama_num].abi[0] == 1)
                    {
                        byte randomByte_r = GetRandomByte(150, 255);
                        byte randomByte_g = GetRandomByte(150, 255);
                        byte randomByte_b = GetRandomByte(150, 255);
                        attack_script.r = randomByte_r;
                        attack_script.b = randomByte_g;
                        attack_script.g = randomByte_b;

                    }
                }

                attack_script.r = eq_tama[id_sikibetu_Tama][tama_num].r;
                attack_script.b = eq_tama[id_sikibetu_Tama][tama_num].b;
                attack_script.g = eq_tama[id_sikibetu_Tama][tama_num].g;

            }
        }
    
    }
    public    byte GetRandomByte(byte min, byte max)
        {
           
            return (byte)random.Next(min, max + 1); // max + 1 to include max in the range
        }
    
}
