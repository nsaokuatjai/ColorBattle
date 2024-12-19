using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public  class HasyadaiD: HasyadaiCOriginal
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(PerformAttacks());
    }

    private IEnumerator PerformAttacks()
    {
        for (int i = 0; i < attack_loop_num; i++)
        {
            // UnityEngine.Debug.Log("attack,mid");
            attack(0);
            attack(1);
            //等間隔で攻撃
            yield return new WaitForSeconds(attack_rate);  // 指定した時間待機
        }
    }
}