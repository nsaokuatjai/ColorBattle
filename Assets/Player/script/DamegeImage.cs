using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;  // í«â¡

public class DamegeImage  : Damege
{



    private UnityEngine.UI.Image image;
  
    void Start()
    {

        image = gameObject.GetComponent<UnityEngine.UI.Image>();  // ïœçX: GetComponent<SpriteRenderer> -> GetComponent<Image>
        tmp_new_Color.a = image.color.a;
        //Color current_color = renderer.material.color;
        //UnityEngine.Debug.Log("r=" + current_color. r);
        //UnityEngine.Debug.Log("g=" + current_color.g);
        //UnityEngine.Debug.Log("b=" + current_color.b);
        tmp_new_Color.a = spriteRenderer.color.a;
        Hp_b *= defens;
        Hp_b *= image.color.b;
        Hp_g *= defens;
        Hp_g*= image.color.g;
        Hp_r *= defens;
        Hp_r*= image.color.r;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

 
    public void damegeColor(byte r, byte g, byte b) {
        damegeCul(r, g, b);
        //UnityEngine.Debug.Log("r=" + tmp_color[0]);
        //      UnityEngine.Debug.Log("g=" + tmp_color[1]);
           UnityEngine.Debug.Log("b=" + Hp_b);
     //   UnityEngine.Debug.Log("  newcolor" + new_Color);
        tmp_new_Color.r=Hp_r/255/defens;
        tmp_new_Color.b=Hp_b/255/defens;   
        tmp_new_Color.g=Hp_g/255/defens;
        //  UnityEngine.Debug.Log("  tmp_new_Color" + tmp_new_Color);
        image.color = tmp_new_Color;
        if(Hp_r < 31*defens && Hp_b <31*defens && Hp_g  <31*defens)
        {
            Destroy(gameObject);
        }
    }

}
