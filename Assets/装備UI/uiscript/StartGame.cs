using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button myButton; // �C���X�y�N�^�Ń{�^�����A�T�C������
    Player player;
    void Start()
    {
        // player = new Player();
        if (myButton != null)
        {
            // �{�^���ɃN���b�N�C�x���g��ǉ�
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
