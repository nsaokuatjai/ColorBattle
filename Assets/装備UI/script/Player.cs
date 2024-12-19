using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //最大装備数
    private static int max_wepon_eq=5;

    struct wepons
    {
         public GameObject hasydai;
        public GameObject[] Hanabi;
        public Tama[][] Tama;
      

    }


    static private  wepons player_wepon0;
    static private wepons player_wepon1;
    static private Item hasyadai0;
    static private Item hasyadai1;

    public static int Max_wepon_eq { get => max_wepon_eq; }
    public  Item Hasyadai0 { get => hasyadai0; set => hasyadai0 = value; }
    public  Item Hasyadai1 { get => hasyadai1; set => hasyadai1 = value; }

    public int maxEq()
    {
        return max_wepon_eq;
    }

    static Player()
    {
        player_wepon0 = new wepons();
        player_wepon1 = new wepons();

        player_wepon0.Hanabi = new GameObject[Max_wepon_eq];

        player_wepon0.Tama = new Tama[Max_wepon_eq][];
        player_wepon1.Hanabi = new GameObject[Max_wepon_eq];
        player_wepon1.Tama = new Tama[Max_wepon_eq][];

        for (int i= 0; i < Max_wepon_eq; i++){
            player_wepon0.Tama[i] = new Tama[Max_wepon_eq];
            player_wepon1.Tama[i] = new Tama[Max_wepon_eq];
        }
    }
    //引数なしで両方律せっと
    public void hasyadaiReset()
    {
        hasyadaiReset(0);
        hasyadaiReset(1);

    }
    //リセットしたい方の武器番号を入れるとリセットできる
    public void hasyadaiReset(int id)
    {
        if (id == 0)
        {
            player_wepon0.hasydai = null;
            for (int i = 0; i < Max_wepon_eq; i++)
            {
                player_wepon0.Hanabi[i] = null;
                for (int j = 0; j < Max_wepon_eq; j++)
                {
                    player_wepon0.Tama[i][j] = null;
                }
            }
        }
        if (id == 1)
        {
            player_wepon1.hasydai = null;
            for (int i = 0; i < Max_wepon_eq; i++)
            {
                player_wepon1.Hanabi[i] = null;
                for (int j = 0; j < Max_wepon_eq; j++)
                {
                    player_wepon1.Tama[i][j] = null;
                }
            }
        }
    }
    //オーバーロード第二引数を入れると弾のリセット
    public void hasyadaiReset(int id,int num)
    {
        if (id == 0)
        {
            player_wepon0.Hanabi[num] = null;
            for (int j = 0; j < Max_wepon_eq; j++)
                {
                    player_wepon0.Tama[num][j] = null;
                }
        }
        if (id == 1)
        {
            player_wepon1.Hanabi[num] = null;
            for (int j = 0; j < Max_wepon_eq; j++)
                {
                    player_wepon1.Tama[num][j] = null;
                }
        }
    }
    public void hasyadaiReset(int id, int num,int num2)
    {
        if (id == 0)
        {
       
                player_wepon0.Tama[num][num2] = null;
            
        }
        if (id == 1)
        {
            player_wepon1.Tama[num][num2] = null;
        }
    }
    public void setWeponHasydai(int id, GameObject hasydai)
    {
        if (id == 0)
        {
            player_wepon0.hasydai = hasydai;
        }
        if (id == 1)
        {
       
            player_wepon1.hasydai = hasydai;
          
        }
    }
    public void setWeponHanabi(int id, int equipment_id, GameObject Hanabi)
    {
        {
            if (id == 0)
            {
                player_wepon0.Hanabi[equipment_id] = Hanabi;
            }
            if (id == 1)
            {
                player_wepon1.Hanabi[equipment_id] = Hanabi;
            }
        }

    }
    public void setWeponTama(int id, int equipment_id,int equipment_id2, Tama Tama)
    {
        {
            if (id == 0)
            {
                player_wepon0.Tama[equipment_id][equipment_id2] = Tama;
            }
            if (id == 1)
            {
                player_wepon1.Tama[equipment_id][equipment_id2] = Tama;
            }
        }

    }
    public GameObject getWeponHasydai(int id)
    {
        
        if (id == 0)
        {
           return  player_wepon0.hasydai;
        }
        if (id == 1)
        {
           return player_wepon1.hasydai;
        }
        return null;
    }
    public GameObject getWeponHanabi(int id, int equipment_id)
    {
        
            if (id == 0)
            {
                 return   player_wepon0.Hanabi[equipment_id];
            }
            if (id == 1)
            {
                    return player_wepon1.Hanabi[equipment_id];
             }
        return null;
        

    }
    public GameObject[] getWeponHanabi(int id)
    {

        if (id == 0)
        {
            return player_wepon0.Hanabi;
        }
        if (id == 1)
        {
            return player_wepon1.Hanabi;
        }
        return null;


    }
    public Tama getWeponTama(int id, int equipment_id, int equipment_id2)
    {
        
            if (id == 0)
            {
               return  player_wepon0.Tama[equipment_id][equipment_id2];
            }
            if (id == 1)
            {
               return player_wepon1.Tama[equipment_id][equipment_id2];
            }
        return null;

    }
    public Tama[] getWeponTama(int id, int equipment_id)
    {

        if (id == 0)
        {
            return player_wepon0.Tama[equipment_id];
        }
        if (id == 1)
        {
            return player_wepon1.Tama[equipment_id];
        }
        return null;

    }
    public Tama[][] getWeponTama(int id)
    {

        if (id == 0)
        {
            return player_wepon0.Tama;
        }
        if (id == 1)
        {
            return player_wepon1.Tama;
        }
        return null;

    }

}
