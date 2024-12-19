using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AttackBoss2 : Attck
{
    //攻撃力をRGBで書く
    ParticleSystem ps;
    public float attack_power;
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
    // Start is called before the first frame update
    protected  void Start()
    {    //その色にする
        GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
        ps = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
