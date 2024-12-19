using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class HasydaiManager : MonoBehaviour
{
    // ・ｽf・ｽo・ｽb・ｽO・ｽp・ｽﾉ費ｿｽ・ｽﾋ托ｿｽ・ｽ・ｽﾇ暦ｿｽ・ｽ・ｽ・ｽ驍ｽ・ｽﾟの配・ｽ・ｽ
    public GameObject[] hashadai;
    // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽ・ｽID
    public int id_hashadai;
    // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽ・ｽID
    public int id_hashadai2;
    // ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽﾄゑｿｽ・ｽ・ｽﾔ火ゑｿｽ・ｽﾇ暦ｿｽ・ｽ・ｽ・ｽ驍ｽ・ｽﾟの配・ｽ・ｽ
    public GameObject[] hanabi;
    // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ花火ゑｿｽID
    public int id_hanabi;
    // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ花火ゑｿｽID
    public int id_hanabi2;
    // ・ｽv・ｽ・ｽ・ｽC・ｽ・ｽ・ｽ[・ｽI・ｽu・ｽW・ｽF・ｽN・ｽg・ｽﾖの参・ｽ・ｽ
    private GameObject player;
    // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg
    private HasyadaiCOriginal hasyadai_script;
    // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg
    private HasyadaiCOriginal hasyadai_script2;
    // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ
    private float ctime;
    // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ
    private float ctime2;
    // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ鯉ｿｽ・ｽﾝのク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ
    private float tmp_ctime = 0;
    // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ鯉ｿｽ・ｽﾝのク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ
    private float tmp_ctime2 = 0;
    // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ弾・ｽ・ｽ・ｽ・ｽ・ｽﾇ暦ｿｽ・ｽ・ｽ・ｽ・ｽz・ｽ・ｽ
    public int[] tama_num;
    // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ弾・ｽ・ｽ・ｽ・ｽ・ｽﾇ暦ｿｽ・ｽ・ｽ・ｽ・ｽz・ｽ・ｽ
    public int[] tama_num2;
    // ・ｽe・ｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽﾖの参・ｽ・ｽ
    public TamaOriginal tama;
    //・ｽﾅバ・ｽO・ｽ・ｽ・ｽ[・ｽh
    public bool debug;
    //・ｽv・ｽ・ｽ・ｽC・ｽ・ｽ・ｽ[・ｽﾌ托ｿｽ・ｽ・ｽ・ｽ・ｽ・ｽﾄゑｿｽ・ｽ髟撰ｿｽ・ｽ・ｽ・ｽﾇ暦ｿｽ・ｽ・ｽ・ｽ・ｽ
    private Player wepon_player;

    //・ｽ{・ｽ・ｽ・ｽﾉ使・ｽ・ｽ・ｽ・ｽ・ｽﾋ托ｿｽ・ｽ・ｽﾇ暦ｿｽ
    private GameObject hasydai_obj0;
    private GameObject hasydai_obj1;

    //・ｽ{・ｽ・ｽ・ｽﾉ使・ｽ・ｽ・ｽﾔ火ゑｿｽ・ｽﾇ暦ｿｽ
    private GameObject[] hanabi_obj0;
    private GameObject[] hanabi_obj1;
    //・ｽ{・ｽ・ｽ・ｽﾉ使・ｽ・ｽTama・ｽ・ｽ・ｽﾇ暦ｿｽ
    private Tama[][] tama_obj0;
    private Tama[][] tama_obj1;

    public GameObject[] Hanabi_obj0 { get => hanabi_obj0; }
    public GameObject[] Hanabi_obj1 { get => hanabi_obj1; }
    public Tama[][] Tama_obj0 { get => tama_obj0; }
    public Tama[][] Tama_obj1 { get => tama_obj1; }
    public GameObject Ctime_obj {  set => ctime_obj = value; }
    public GameObject Ctime_obj2 { set => ctime_obj2 = value; }

    private GameObject ctime_obj;
    private GameObject ctime_obj2;

    private UnityEngine.UI.Image ctime_image;
    private UnityEngine.UI.Image ctime_image1;
    private Color color_off = new Color(0,0,0,0);
    private Color color_on = new Color(1, 1, 1, 1);

    // Start・ｽﾍ最擾ｿｽ・ｽﾌフ・ｽ・ｽ・ｽ[・ｽ・ｽ・ｽﾅ呼ばゑｿｽ驛・ｿｽ\・ｽb・ｽh
    void Start()
    {
       
        // ・ｽv・ｽ・ｽ・ｽC・ｽ・ｽ・ｽ[・ｽI・ｽu・ｽW・ｽF・ｽN・ｽg・ｽ・ｽ・ｽ謫ｾ
        player = GameObject.FindGameObjectWithTag("Player");
        wepon_player = new Player();
        if (debug)
        {
            // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽ・ｽ・ｽ謫ｾ
            hasyadai_script = hashadai[id_hashadai].GetComponent<HasyadaiCOriginal>();
            // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽ・ｽ・ｽ謫ｾ
            hasyadai_script2 = hashadai[id_hashadai2].GetComponent<HasyadaiCOriginal>();


            // ・ｽ・ｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽ・ｽ・ｽ謫ｾ・ｽﾅゑｿｽ・ｽﾈゑｿｽ・ｽ・ｽ・ｽ・ｽ・ｽ鼾・ｿｽﾌエ・ｽ・ｽ・ｽ[・ｽ・ｽ・ｽO
            if (hasyadai_script == null) { UnityEngine.Debug.Log("erray"); }
            if (hasyadai_script2 == null) { UnityEngine.Debug.Log("erray"); }

            // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ・ｽ・ｽ・ｽ謫ｾ
            ctime = hasyadai_script.ctime;
            ctime2 = hasyadai_script2.ctime;
        }
        else
        {
            resetWepon();
        }
      
    }
   public  void resetWepon()
    {
        UnityEngine.Debug.Log(ctime_obj);
        UnityEngine.Debug.Log(ctime_obj2);
        UnityEngine.Debug.Log(ctime_image);
        UnityEngine.Debug.Log(ctime_image1);
        if (ctime_obj !=null&& ctime_image==null)  ctime_image = ctime_obj.GetComponent<UnityEngine.UI.Image>();
        if (ctime_obj2 != null && ctime_image1 == null)  ctime_image1 = ctime_obj2.GetComponent<UnityEngine.UI.Image>();
        int lon = wepon_player.maxEq();
         hasydai_obj0 =wepon_player.getWeponHasydai(0);
        hasydai_obj1 = wepon_player.getWeponHasydai(1);
        // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽ・ｽ・ｽ謫ｾ
        if (hasydai_obj0 != null) {
            hasyadai_script = hasydai_obj0.GetComponent<HasyadaiCOriginal>();
            ctime = hasyadai_script.ctime;
            hanabi_obj0 = new GameObject[lon];
            hanabi_obj0 = wepon_player.getWeponHanabi(0);
            tama_obj0 = new Tama[lon][];
            tama_obj0 = wepon_player.getWeponTama(0);
           
        }
        // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ費ｿｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽ・ｽ・ｽ謫ｾ
        if (hasydai_obj1 != null)
        {
            UnityEngine.Debug.Log(hasydai_obj1);
            hasyadai_script2 = hasydai_obj1.GetComponent<HasyadaiCOriginal>();
            ctime2 = hasyadai_script2.ctime;
            hanabi_obj1 = new GameObject[lon];
            hanabi_obj1 = wepon_player.getWeponHanabi(1);
            tama_obj1 = new Tama[lon][];
            tama_obj1 = wepon_player.getWeponTama(1);
        }
        UnityEngine.Debug.Log(ctime_image);
        UnityEngine.Debug.Log(ctime_image1);
        UnityEngine.Debug.Log(wepon_player.Hasyadai0);
        UnityEngine.Debug.Log(wepon_player.Hasyadai1);

        //クールタイムを確認するためのobjに画像データを取得
        //nullの場合は表しない(透明にする)
        if (wepon_player.Hasyadai0 != null)
        {
            ctime_image.sprite = wepon_player.Hasyadai0.itemImege;
            ctime_image.color = color_on;
        }
        else {
            ctime_image.sprite = null;
            ctime_image.color = color_off;
        }
        if (wepon_player.Hasyadai1 != null)
        {
            ctime_image1.sprite = wepon_player.Hasyadai1.itemImege;
            ctime_image1.color = color_on;
        }
        else
        {
            ctime_image1.sprite = null;
            ctime_image1.color = color_off;
        }


    }
    // Update・ｽﾍ厄ｿｽ・ｽt・ｽ・ｽ{・ｽ[・ｽ・ｽ・ｽﾄばゑｿｽ驛・ｿｽ\・ｽb・ｽh
    void Update()
    {
        if (debug)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack(id_hashadai, 0);
            }
            if (Input.GetMouseButtonDown(1))
            {
                attack(id_hashadai2, 1);
            }
        }
        if(!debug){ 
        // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ鯉ｿｽ・ｽﾝのク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ・ｽ・ｽ・ｽX・ｽV
        tmp_ctime += Time.deltaTime;
        // ・ｽ・ｽ・ｽN・ｽ・ｽ・ｽb・ｽN・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽA・ｽN・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ・ｽ・ｽ・ｽo・ｽﾟゑｿｽ・ｽﾄゑｿｽ・ｽ・ｽ鼾・ｿｽﾉ攻・ｽ・ｽ
        if (tmp_ctime > ctime)
        {

            if (Input.GetMouseButtonDown(0))
            {

                tmp_ctime = 0;
                attack(id_hashadai, 0);
            }
            if (ctime_image.sprite != null)
            {
                ctime_image.color = color_on;
            }
        }
        else
        {
            ctime_image.color = color_off;
        }


        // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽp・ｽﾌ鯉ｿｽ・ｽﾝのク・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ・ｽ・ｽ・ｽX・ｽV
        tmp_ctime2 += Time.deltaTime;
        // ・ｽE・ｽN・ｽ・ｽ・ｽb・ｽN・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽA・ｽN・ｽ[・ｽ・ｽ・ｽ^・ｽC・ｽ・ｽ・ｽ・ｽ・ｽo・ｽﾟゑｿｽ・ｽﾄゑｿｽ・ｽ・ｽ鼾・ｿｽﾉ攻・ｽ・ｽ
        if (tmp_ctime2 > ctime2)
        {
            if (Input.GetMouseButtonDown(1))
            {
                tmp_ctime2 = 0;
                attack(id_hashadai2, 1);
            }

            if (ctime_image1.sprite != null)
            {
                ctime_image1.color = color_on;
            }
        }
        else
        {
            ctime_image1.color = color_off;
        }
    }
    }

    // ・ｽ・ｽ・ｽﾋ托ｿｽ・ｽ・ｽC・ｽ・ｽ・ｽX・ｽ^・ｽ・ｽ・ｽX・ｽ・ｽ・ｽ・ｽ・ｽA・ｽU・ｽ・ｽ・ｽ・ｽ・ｽJ・ｽn・ｽ・ｽ・ｽ驛・ｿｽ\・ｽb・ｽh
    void attack(int id, int a)
    {
        Vector3 playerPosition = player.transform.position; // 繝励Ξ繧､繝､繝ｼ縺ｮ迴ｾ蝨ｨ縺ｮ菴咲ｽｮ繧貞叙蠕・
        if (debug)
        {
            // ・ｽ・ｽ・ｽﾋ托ｿｽ・ｽ・ｽv・ｽ・ｽ・ｽC・ｽ・ｽ・ｽ[・ｽﾌ位置・ｽﾉイ・ｽ・ｽ・ｽX・ｽ^・ｽ・ｽ・ｽX・ｽ・ｽ
            //GameObject obj = Instantiate<GameObject>(hashadai[id], player.transform.position, Quaternion.identity);
            GameObject obj = Instantiate<GameObject>(hashadai[id], playerPosition, Quaternion.identity);
            // ・ｽ・ｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽ・ｽ・ｽ謫ｾ
            HasyadaiCOriginal script = obj.GetComponent<HasyadaiCOriginal>();
            // ・ｽ・ｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽﾉマ・ｽl・ｽ[・ｽW・ｽ・ｽ・ｽ[・ｽ・ｽﾝ抵ｿｽ
            script.hasydai_manager = this;
            // ・ｽ・ｽ・ｽﾋ托ｿｽﾌ趣ｿｽ・ｽ・ｽID・ｽ・ｽﾝ抵ｿｽ
            script.id_sikibetu = a;
        }
        else
        {
            GameObject obj=null;
         if (a==0&& hasydai_obj0!=null)    obj = Instantiate<GameObject>(hasydai_obj0, player.transform.position, Quaternion.identity);
          else if(a==1&&hasydai_obj1 != null)  obj = Instantiate<GameObject>(hasydai_obj1, player.transform.position, Quaternion.identity);
            // 発射台のスクリプトを取得
            if (obj == null) return;
             HasyadaiCOriginal script = obj.GetComponent<HasyadaiCOriginal>();
            // ・ｽ・ｽ・ｽﾋ托ｿｽﾌス・ｽN・ｽ・ｽ・ｽv・ｽg・ｽﾉマ・ｽl・ｽ[・ｽW・ｽ・ｽ・ｽ[・ｽ・ｽﾝ抵ｿｽ
            script.hasydai_manager = this;
            // ・ｽ・ｽ・ｽﾋ托ｿｽﾌ趣ｿｽ・ｽ・ｽID・ｽ・ｽﾝ抵ｿｽ
            script.id_sikibetu = a;
        }
    }
}
