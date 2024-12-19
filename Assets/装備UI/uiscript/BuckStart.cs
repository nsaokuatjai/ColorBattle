using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuckStart : MonoBehaviour
{
    public Button myButton; // インスペクタでボタンをアサインする
    void Start()
    {
        if (myButton != null)
        {
            // ボタンにクリックイベントを追加
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        //ゲームオーバーオブジェクトを非表示に
        SceneManager.LoadScene("title");
    }

}
