using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exgame : MonoBehaviour
{
    public GameObject ex_game_obj;
    // Start is called before the first frame update
    public Button myButton; // �C���X�y�N�^�Ń{�^�����A�T�C������
    void Start()
    {
        if (myButton != null)
        {
            // �{�^���ɃN���b�N�C�x���g��ǉ�
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Update is called once per frame
    public void OnButtonClick()
    {
        ex_game_obj.SetActive(true);
    }
}
