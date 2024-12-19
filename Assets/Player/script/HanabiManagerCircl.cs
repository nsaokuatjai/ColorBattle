using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanabiManagerCircl : HanabiManegerOriginal
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
            for (int j = 0; j < equipment_tama_num; j++)
            {
                attack(id_hanabi, tama_num[j]);
            }

            //“™ŠÔŠu‚ÅUŒ‚
            yield return new WaitForSeconds(attack_rate);  // Žw’è‚µ‚½ŽžŠÔ‘Ò‹@


        }
    }
}
