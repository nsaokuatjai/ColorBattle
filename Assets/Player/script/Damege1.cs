using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege1 : Damege
{

    //// 防御力
    //public float defens;
   
    //void Start()
    //{  
    //}

    //// Update is called once per frame
    //void Update()
    //{
      
    //}
    ////ダメージを受けた時の色の処理引数の色分ダメージを受ける
    //public void damegeColor(byte r, byte g, byte b) {

    //}
    ////ダメージ計算をRGBで行う,biockは防御力
    //private byte[] damegeCul(byte r, byte g, byte b, float biock)
    //{

    //    Renderer renderer = GetComponent<Renderer>();
    //    //今の色を取得
    //    Color current_color = renderer.material.color;
    //    //ダメージを受けた後の結果を記録する配列
    //    byte[] result = new byte[3];
    //    byte tmpr = (byte)(current_color.r * 255f);
    //    byte tmpg = (byte)(current_color.g * 255f);
    //    byte tmpb = (byte)(current_color.b * 255f); 
    //    UnityEngine.Debug.Log("tmpr=" + tmpr);
    //    if (tmpr != 0)
    //    {   if (tmpr - ((255 - r) / biock) < 0) tmpr = 0;
    //        else tmpr = (byte)(tmpr - ((255 - r) / biock));
    //    }
    //    UnityEngine.Debug.Log("tmpr=" + tmpr);

    //    if (tmpb != 0)
    //    {
    //        if (tmpb - ((255 - b) / biock) < 0) tmpb = 0;
    //        else tmpb = (byte)(tmpb - ((255 - b) / biock));
    //    }

    //    if (tmpg != 0)
    //    {
    //        if (tmpg - ((255 - g) / biock) < 0) tmpg = 0;
    //        else tmpg = (byte)(tmpg - ((255 - g) / biock));
    //    }


    //    result[0] = tmpr;
    //    result[1] = tmpg;
    //    result[2] = tmpb;
    //    return result;
    //} 
}
