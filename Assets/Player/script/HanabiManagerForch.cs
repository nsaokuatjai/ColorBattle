using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanabiManagerForch : HanabiManegerOriginal
{
    private Vector2 tmp_Vector;
    public float Vector_def;
    public float speed;
    private int count=0;
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
                for (int id = 0; id < hanabi.Length; id++)
                {

                    attack(id, tama_num[j]);
                    count += 1;
                }
                speed -= Vector_def;
                //“™ŠÔŠu‚ÅUŒ‚
                yield return new WaitForSeconds(attack_rate);  // Žw’è‚µ‚½ŽžŠÔ‘Ò‹@
            }

         


        }
    }
    public void attack(int id, int tama_num)
    {
        for (int i = 0; i < attack_num; i++)
        {
            GameObject obj = Instantiate<GameObject>(hanabi[id], this.transform.position, Quaternion.identity);
            AttackOriginal attack_script = obj.GetComponent<AttackOriginal>();
            ParticleShooter2 script_shooter = obj.GetComponent<ParticleShooter2>();
            float tmpangle = 360 / (hanabi.Length);
            float angleRadians = tmpangle * (id + 1) * Mathf.Deg2Rad;
            float cosAngle = Mathf.Cos(angleRadians);
            float sinAngle = Mathf.Sin(angleRadians);
  
            tmp_Vector.x = cosAngle* speed;
            tmp_Vector.y = sinAngle* speed;
            script_shooter.velocity = tmp_Vector;
            UnityEngine.Debug.Log("hasyadai_power" + hasyadai_power);
            UnityEngine.Debug.Log("hanabi_power" + hanabi_power);
            if (hasyadai_power == null) UnityEngine.Debug.Log("hasypowererr");
            if (hanabi_power == null) UnityEngine.Debug.Log("hanabi_power");
            if (attack_script == null) UnityEngine.Debug.Log("vattack_script");
            attack_script.power = hasyadai_power * hanabi_power;
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
    }

    
}