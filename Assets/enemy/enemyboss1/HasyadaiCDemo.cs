using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public  class HasyadaiCDemo: HasyadaiCOriginal
{
    public int equipment;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(PerformAttacks());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator PerformAttacks()
    {
        float lon = 10f;//ë¨Ç≥ÇèkÇﬂÇÈ
        for (int i = 0; i < attack_loop_num; i++)
        {
            // UnityEngine.Debug.Log("attack,mid");
            //ìôä‘äuÇ≈çUåÇ
            yield return new WaitForSeconds(attack_rate);  // éwíËÇµÇΩéûä‘ë“ã@


            for (int j = 0; j< equipment; j++) {
        
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                UnityEngine.Debug.Log((Vector3)(rb.velocity / lon));
                attack(j, player.transform.position+(Vector3)(rb.velocity/lon));
        }
          
        }
    }
    public  void attack(int id,Vector3 vector)
    {
        GameObject obj = Instantiate<GameObject>(hasydai[id], vector, Quaternion.identity);
        HasyadaiOriginal script = obj.GetComponent<HasyadaiOriginal>();
        if (script != null)
        {
            script.hasyadai_power = hasyadai_power;
            script.hasydai_manager = hasydai_manager;
            script.equipment_hanabi_num = equipment_hanabi_num;
            script.id_sikibetu = id_sikibetu;
        }
    }
}