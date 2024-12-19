using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class A : MonoBehaviour
{
    Player player;
        public Button myButton; // インスペクタでボタンをアサインする
        void Start()
        {
        player = new Player();
            if (myButton != null)
            {
                // ボタンにクリックイベントを追加
                myButton.onClick.AddListener(OnButtonClick);
            }
        }

        void OnButtonClick()
        {
            SceneManager.LoadScene("test");
            int i = 0;
            UnityEngine.Debug.Log(player.getWeponHasydai(0));
            foreach (var item in   player.getWeponHanabi(0))
            {
                UnityEngine.Debug.Log(item + " " + i);
                i++;
            }
        for (i = 0; i < 5; i++)
        {
            foreach (var item in player.getWeponTama(0, i))
            {
                UnityEngine.Debug.Log(item + " " + i);
            }
        }
        i = 0;
            UnityEngine.Debug.Log(player.getWeponHasydai(1));
            foreach (var item in player.getWeponHanabi(1))
            {
                UnityEngine.Debug.Log(item + " " + i);
                i++;
            }
            for (i = 0; i < 5; i++)
            {
                foreach (var item in player.getWeponTama(1, i))
                {
                    UnityEngine.Debug.Log(item + " " + i);
                }
            }
        }
        //void Update()
        //{
        //int i = 0;
        //    UnityEngine.Debug.Log(player.getWeponHasydai(1));
        //    foreach (var item in player.getWeponHanabi(1))
        //    {
        //        UnityEngine.Debug.Log(item + " " + i);
        //        i++;
        //    }
        //    for (i = 0; i < 5; i++)
        //    {
        //        foreach (var item in player.getWeponTama(1, i))
        //        {
        //            UnityEngine.Debug.Log(item + " " + i);
        //        }
        //    }
        //}
    }

