using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossmane : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    public GameObject player_obj;
    private GameObject player;
    //�Q�[���I�[�o�[�̎��\������
    public GameObject game_over_obj;
    //�Q�[���N���A�̎��ɕ\������
    public GameObject game_clear_obj;


    //�o�����Ă���G���Ǘ�
    private GameObject[] gameObject;

    public GameObject ctime_obj;
    public GameObject ctime_obj1;

    public bool stopupdate;
    public SoundManager soundManager;
    public void startgame()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        gameObject = objs;
        stopupdate = false;


    }
    void Awake()
    {   //�v���[���[�̐���
        player = Instantiate<GameObject>(player_obj, offset, Quaternion.identity);
        stopupdate = true;
        HasydaiManager hasydaiManager = player.GetComponent<HasydaiManager>();
        hasydaiManager.Ctime_obj = ctime_obj;
        hasydaiManager.Ctime_obj2 = ctime_obj1;


    }
    void Start()
    {

        soundManager.PlayBGM(3);
    }
    //�v���C���[�����񂾎��̏���
    void playerDie()
    {
        game_over_obj.SetActive(true);
        stopupdate=true;
    }

    //�t���A�N���A�̏���
    void clearFlooer()
    {
        soundManager.PlayBGM(1);
        game_clear_obj.SetActive(true);
        stopupdate = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (stopupdate) return;
        if (player == null) playerDie();
        int i=0;
        foreach (var obj in gameObject)
        {
            if (obj != null) break;
            i++;
        }
        if (i == gameObject.Length) clearFlooer();
    }

}
 
