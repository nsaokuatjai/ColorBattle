using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Attck : AttackOriginal
{
    //攻撃力をRGBで書く
    ParticleSystem ps;

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
    // Start is called before the first frame update
    protected  void Start()
    {    //その色にする
        GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
        ps = GetComponent<ParticleSystem>();
        //  ps.main.startColor= new Color32(r, g, b, 255);
        //if (ps != null)
        //{
        //    var main = ps.main;
        //    main.startColor = new ParticleSystem.MinMaxGradient(new Color32(r, g, b, 255)); // 赤色
        //}
    }

}
