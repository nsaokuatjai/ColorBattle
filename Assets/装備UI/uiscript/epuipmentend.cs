using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class epuipmentend : MonoBehaviour
{
    // Start is called before the first frame update
    public Button myButton; // �C���X�y�N�^�Ń{�^�����A�T�C������
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (myButton != null)
        {
            // �{�^���ɃN���b�N�C�x���g��ǉ�
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Update is called once per frame
    public void OnButtonClick()
    {
  

            gameManager.next_game = true;
    }
}
