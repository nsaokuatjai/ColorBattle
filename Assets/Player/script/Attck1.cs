using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Attck1 : AttackOriginal
{
    //攻撃力をRGBで書く
    ParticleSystem ps;
    Attck1(Tama tama)
    {
        ps = GetComponent<ParticleSystem>();
        r = tama.r;
        b=tama.b;
        g=tama.g;
        var main = ps.main;
        main.startColor = new ParticleSystem.MinMaxGradient(new Color32(r, g, b, 255)); 
    }
    //あったた時の判定
    protected override void attack(GameObject other)
    {
        //  UnityEngine.Debug.Log("eleer");
        Damege dam = other.GetComponent<Damege>();
        //エラーチェック
        if (dam != null)
        {
            dam.damegeColor(r, g, b);
        }
    }
   

  
}
