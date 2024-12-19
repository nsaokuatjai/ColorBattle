using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{


    public float defens;
    public SpriteRenderer spriteRenderer ;
    protected Color32 new_Color;
    protected Color tmp_new_Color;
    byte[] tmp_color = new byte[3];
    protected float Hp_r=255;
    protected float Hp_g=255;
    protected float Hp_b=255;
    void Start()
    {  
        if(spriteRenderer==null)spriteRenderer = GetComponent<SpriteRenderer>();
        //Color current_color = renderer.material.color;
        //UnityEngine.Debug.Log("r=" + current_color. r);
        //UnityEngine.Debug.Log("g=" + current_color.g);
        //UnityEngine.Debug.Log("b=" + current_color.b);
        tmp_new_Color.a = spriteRenderer.color.a;
        Hp_b *= defens;
        Hp_b *= spriteRenderer.color.b;
        Hp_g *= defens;
        Hp_g*= spriteRenderer.color.g;
        Hp_r *= defens;
        Hp_r*= spriteRenderer.color.r;
    }
    protected float Hp_r_tmp;
    protected float Hp_g_tmp;
    protected float Hp_b_tmp;
    // Update is called once per frame
    void Update()
    {
        //hPのデバッグ用
      if(Hp_r_tmp!= Hp_r || Hp_g_tmp != Hp_g || Hp_b != Hp_b_tmp)
        {
            UnityEngine.Debug.Log("(r,g,b)="+"("+Hp_r+","+Hp_g+","+Hp_b+")");
        }
        Hp_r_tmp = Hp_r;
        Hp_g_tmp= Hp_g;
        Hp_b_tmp= Hp_b;
    }

 
    public void damegeColor(byte r, byte g, byte b) {
        damegeCul(r, g, b);
        //UnityEngine.Debug.Log("r=" + tmp_color[0]);
        //      UnityEngine.Debug.Log("g=" + tmp_color[1]);
          // UnityEngine.Debug.Log("b=" + Hp_b);
     //   UnityEngine.Debug.Log("  newcolor" + new_Color);
        tmp_new_Color.r=Hp_r/255/defens;
        tmp_new_Color.b=Hp_b/255/defens;   
        tmp_new_Color.g=Hp_g/255/defens;
      //  UnityEngine.Debug.Log("  tmp_new_Color" + tmp_new_Color);
        spriteRenderer.color = tmp_new_Color;
        if(Hp_r < 31*defens && Hp_b <31*defens && Hp_g  <31*defens)
        {
            Destroy(gameObject);
        }
    }

    protected　void damegeCul(byte r, byte g, byte b)
    {

       

      
        if (Hp_r != 0)
        {   if (Hp_r - ((g+b)) < 0) Hp_r = 0;
            else Hp_r = (Hp_r - ((g + b) ));
        }
      //  UnityEngine.Debug.Log("tmpr=" + tmpr);

        if (Hp_b != 0)
        {
            if (Hp_b - ((r+g ) ) < 0) Hp_b = 0;
            else Hp_b =(Hp_b - ((r+g) ));
        }

        if (Hp_g != 0)
        {
            if (Hp_g - ((r+b) ) < 0) Hp_g = 0;
            else Hp_g = (Hp_g - (r+b));
        }

    } 
}
