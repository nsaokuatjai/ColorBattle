using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuckStart : MonoBehaviour
{
    public Button myButton; // �C���X�y�N�^�Ń{�^�����A�T�C������
    void Start()
    {
        if (myButton != null)
        {
            // �{�^���ɃN���b�N�C�x���g��ǉ�
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        //�Q�[���I�[�o�[�I�u�W�F�N�g���\����
        SceneManager.LoadScene("title");
    }

}
