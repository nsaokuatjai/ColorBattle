using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanabiManager : HanabiManegerOriginal
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(PerformAttacks());
    }

    private IEnumerator PerformAttacks()
    {
        //���[�v��U������
        for (int i = 0; i < attack_loop_num; i++)
        {
            // UnityEngine.Debug.Log("attack,mid");
            for (int j = 0; j < equipment_tama_num; j++)
            {
        
                if (hasydai_manager.debug)
                {
                    if(tama_num.Length > j)attack(id_hanabi, tama_num[j]);
                }
                else attack(id_hanabi, j);
            }

            //���Ԋu�ōU��
            yield return new WaitForSeconds(attack_rate);  // �w�肵�����ԑҋ@


        }
    }
  
}
