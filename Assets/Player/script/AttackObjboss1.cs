using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class AttackObjboss1 : AttackOriginalObj
{
    public float attack_power;
    public int bunnretu;
    public float size;
    public float count;
    public float speed;
    public float speed_y;
    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
        
            attack(collision.gameObject);
           
        }

        if (bunnretu != 0)
        {
            for (int i = 0; i < count; i++)
            {
             
                float tmpangle = 180 / (count + 1);
                float angleRadians = tmpangle * (i+1) * Mathf.Deg2Rad;

                // 単位ベクトル（方向ベクトル）を計算
                float cosAngle = Mathf.Cos(angleRadians);
                float sinAngle = Mathf.Sin(angleRadians);
                Vector2 velocity = new Vector2(cosAngle, sinAngle+ speed_y) * speed;
            
                GameObject obj = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
                obj.transform.localScale = gameObject.transform.localScale * size;

                AttackObjboss1 script = obj.GetComponent<AttackObjboss1>();
                if(script==null) UnityEngine.Debug.LogError(gameObject);
                script.attack_power = attack_power / count;
                script.bunnretu = bunnretu - 1;
                Rigidbody2D rd = obj.GetComponent<Rigidbody2D>();
                rd.velocity = velocity;
              
            }
          
        }
        Destroy(gameObject);

    }
    protected override void attack(GameObject other)
    {
        //  UnityEngine.Debug.Log("eleer");
        Damege dam = other.GetComponent<Damege>();
        //エラーチェック
        if (dam != null)
        {
            byte tmp_r = (byte)(r * attack_power);
            byte tmp_g = (byte)(g * attack_power);
            byte tmp_b = (byte)(b * attack_power);
            dam.damegeColor(r, g, b);
        }
    }
}
