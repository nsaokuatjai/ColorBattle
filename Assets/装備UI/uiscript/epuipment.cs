using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class epuipment : MonoBehaviour
{
    // Start is called before the first frame update
    public Button myButton; // インスペクタでボタンをアサインする
    public bool yesno;
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
        gameManager.eqipment_yes_no_obj.SetActive(false);
        gameManager.game_clear_obj.SetActive(false);
        if (yesno)
        {
            gameManager.eqipument_obj.SetActive(true);
        }
        else
        {
            gameManager.next_game = true;
        }
    }
}
