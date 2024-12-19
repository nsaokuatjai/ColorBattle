using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class epuipmentend : MonoBehaviour
{
    // Start is called before the first frame update
    public Button myButton; // インスペクタでボタンをアサインする
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (myButton != null)
        {
            // ボタンにクリックイベントを追加
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Update is called once per frame
    public void OnButtonClick()
    {
  

            gameManager.next_game = true;
    }
}
