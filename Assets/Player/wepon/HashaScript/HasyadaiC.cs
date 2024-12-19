using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public  class HasyadaiC: HasyadaiCOriginal
{
    public int equipment;

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


            for (int j = 0; j< equipment; j++) {
                attack(j);
        }
            //���Ԋu�ōU��
            yield return new WaitForSeconds(attack_rate);  // �w�肵�����ԑҋ@

        }
    }
}