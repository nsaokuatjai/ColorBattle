using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button myButton; // インスペクタでボタンをアサインする
    Player player;
    void Start()
    {
        // player = new Player();
        if (myButton != null)
        {
            // ボタンにクリックイベントを追加
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        //player.hasyadaiReset();
        SceneManager.LoadScene("mainbattle");
    }

}
