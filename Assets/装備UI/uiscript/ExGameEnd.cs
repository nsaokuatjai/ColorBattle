using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExgameEnd : MonoBehaviour
{
    public GameObject ex_game_obj;
    public GameObject ex_game_obj2;
    // Start is called before the first frame update
    public Button myButton; // インスペクタでボタンをアサインする
    void Start()
    {
        if (myButton != null)
        {
            // ボタンにクリックイベントを追加
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Update is called once per frame
    public void OnButtonClick()
    {
        ex_game_obj2.SetActive(true);
        ex_game_obj.SetActive(false);

    }
}
