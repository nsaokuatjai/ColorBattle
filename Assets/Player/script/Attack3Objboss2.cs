using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Attack3Objboss1 : AttackOriginalObj
{

    public float speed;
    public float attack_power;
    public Rigidbody2D rb;
    public float max_angle;
    private GameObject player;
    Vector2 tmp=new Vector2();
    float time=0;
    public float dont_move_time;

    void Update()
    {  player = GameObject.FindGameObjectWithTag("Player");
        time += Time.deltaTime;
        if (dont_move_time > time) return;
        Vector2 directionToPlayer = player.transform.position - gameObject.transform.position;
        float angleToTarget = Vector2.SignedAngle(rb.velocity, directionToPlayer);

        if(angleToTarget<-max_angle)angleToTarget = -max_angle;
        if( angleToTarget > max_angle) angleToTarget = max_angle;
     //   UnityEngine.Debug.Log(angleToTarget);
        RotateVector(rb.velocity, angleToTarget);
      //  UnityEngine.Debug.Log(tmp);
        rb.velocity = tmp.normalized * speed;


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("attack3");
            attack(collision.gameObject);
            Destroy(gameObject);
        }
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
    // ベクトルを指定した角度だけ回転させるメソッド
    void RotateVector(Vector2 vector, float angle)
    {
        float radian = angle * Mathf.Deg2Rad; // 度をラジアンに変換
        float cos = Mathf.Cos(radian);
        float sin = Mathf.Sin(radian);
        if (vector.x == 0f && vector.y == 0f) vector.y = -0.1f;
        // 回転行列を使ってベクトルを回転
        float x = vector.x * cos - vector.y * sin;
        float y = vector.x * sin + vector.y * cos;
        tmp.x= x;
        tmp.y= y;
    }
}
