using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class HasydaiManager : MonoBehaviour
{
    // �E�f�E�o�E�b�E�O�E�p�E�ɔ��E�ˑ��E��E�Ǘ��E��E��E�邽�E�߂̔z�E��E�
    public GameObject[] hashadai;
    // �E��E��E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ��E�ID
    public int id_hashadai;
    // �E�E�E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ��E�ID
    public int id_hashadai2;
    // �E��E��E��E��E��E��E�Ă��E��E�ԉ΂��E�Ǘ��E��E��E�邽�E�߂̔z�E��E�
    public GameObject[] hanabi;
    // �E�E�E�N�E��E��E�b�E�N�E�p�E�̉ԉ΂�ID
    public int id_hanabi;
    // �E��E��E�N�E��E��E�b�E�N�E�p�E�̉ԉ΂�ID
    public int id_hanabi2;
    // �E�v�E��E��E�C�E��E��E�[�E�I�E�u�E�W�E�F�E�N�E�g�E�ւ̎Q�E��E�
    private GameObject player;
    // �E��E��E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ�̃X�E�N�E��E��E�v�E�g
    private HasyadaiCOriginal hasyadai_script;
    // �E�E�E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ�̃X�E�N�E��E��E�v�E�g
    private HasyadaiCOriginal hasyadai_script2;
    // �E��E��E�N�E��E��E�b�E�N�E�p�E�̃N�E�[�E��E��E�^�E�C�E��E�
    private float ctime;
    // �E�E�E�N�E��E��E�b�E�N�E�p�E�̃N�E�[�E��E��E�^�E�C�E��E�
    private float ctime2;
    // �E��E��E�N�E��E��E�b�E�N�E�p�E�̌��E�݂̃N�E�[�E��E��E�^�E�C�E��E�
    private float tmp_ctime = 0;
    // �E�E�E�N�E��E��E�b�E�N�E�p�E�̌��E�݂̃N�E�[�E��E��E�^�E�C�E��E�
    private float tmp_ctime2 = 0;
    // �E��E��E�N�E��E��E�b�E�N�E�p�E�̒e�E��E��E��E��E�Ǘ��E��E��E��E�z�E��E�
    public int[] tama_num;
    // �E�E�E�N�E��E��E�b�E�N�E�p�E�̒e�E��E��E��E��E�Ǘ��E��E��E��E�z�E��E�
    public int[] tama_num2;
    // �E�e�E�̃X�E�N�E��E��E�v�E�g�E�ւ̎Q�E��E�
    public TamaOriginal tama;
    //�E�Ńo�E�O�E��E��E�[�E�h
    public bool debug;
    //�E�v�E��E��E�C�E��E��E�[�E�̑��E��E��E��E��E�Ă��E�镐��E��E��E�Ǘ��E��E��E��E�
    private Player wepon_player;

    //�E�{�E��E��E�Ɏg�E��E��E��E��E�ˑ��E��E�Ǘ�
    private GameObject hasydai_obj0;
    private GameObject hasydai_obj1;

    //�E�{�E��E��E�Ɏg�E��E��E�ԉ΂��E�Ǘ�
    private GameObject[] hanabi_obj0;
    private GameObject[] hanabi_obj1;
    //�E�{�E��E��E�Ɏg�E��E�Tama�E��E��E�Ǘ�
    private Tama[][] tama_obj0;
    private Tama[][] tama_obj1;

    public GameObject[] Hanabi_obj0 { get => hanabi_obj0; }
    public GameObject[] Hanabi_obj1 { get => hanabi_obj1; }
    public Tama[][] Tama_obj0 { get => tama_obj0; }
    public Tama[][] Tama_obj1 { get => tama_obj1; }
    public GameObject Ctime_obj {  set => ctime_obj = value; }
    public GameObject Ctime_obj2 { set => ctime_obj2 = value; }

    private GameObject ctime_obj;
    private GameObject ctime_obj2;

    private UnityEngine.UI.Image ctime_image;
    private UnityEngine.UI.Image ctime_image1;
    private Color color_off = new Color(0,0,0,0);
    private Color color_on = new Color(1, 1, 1, 1);

    // Start�E�͍ŏ��E�̃t�E��E��E�[�E��E��E�ŌĂ΂�郁E��\�E�b�E�h
    void Start()
    {
       
        // �E�v�E��E��E�C�E��E��E�[�E�I�E�u�E�W�E�F�E�N�E�g�E��E��E�擾
        player = GameObject.FindGameObjectWithTag("Player");
        wepon_player = new Player();
        if (debug)
        {
            // �E��E��E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ�̃X�E�N�E��E��E�v�E�g�E��E��E�擾
            hasyadai_script = hashadai[id_hashadai].GetComponent<HasyadaiCOriginal>();
            // �E�E�E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ�̃X�E�N�E��E��E�v�E�g�E��E��E�擾
            hasyadai_script2 = hashadai[id_hashadai2].GetComponent<HasyadaiCOriginal>();


            // �E��E��E�ˑ�̃X�E�N�E��E��E�v�E�g�E��E��E�擾�E�ł��E�Ȃ��E��E��E��E��E�ꍁE��̃G�E��E��E�[�E��E��E�O
            if (hasyadai_script == null) { UnityEngine.Debug.Log("erray"); }
            if (hasyadai_script2 == null) { UnityEngine.Debug.Log("erray"); }

            // �E��E��E�N�E��E��E�b�E�N�E�p�E�̃N�E�[�E��E��E�^�E�C�E��E��E��E��E�擾
            ctime = hasyadai_script.ctime;
            ctime2 = hasyadai_script2.ctime;
        }
        else
        {
            resetWepon();
        }
      
    }
   public  void resetWepon()
    {
        UnityEngine.Debug.Log(ctime_obj);
        UnityEngine.Debug.Log(ctime_obj2);
        UnityEngine.Debug.Log(ctime_image);
        UnityEngine.Debug.Log(ctime_image1);
        if (ctime_obj !=null&& ctime_image==null)  ctime_image = ctime_obj.GetComponent<UnityEngine.UI.Image>();
        if (ctime_obj2 != null && ctime_image1 == null)  ctime_image1 = ctime_obj2.GetComponent<UnityEngine.UI.Image>();
        int lon = wepon_player.maxEq();
         hasydai_obj0 =wepon_player.getWeponHasydai(0);
        hasydai_obj1 = wepon_player.getWeponHasydai(1);
        // �E��E��E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ�̃X�E�N�E��E��E�v�E�g�E��E��E�擾
        if (hasydai_obj0 != null) {
            hasyadai_script = hasydai_obj0.GetComponent<HasyadaiCOriginal>();
            ctime = hasyadai_script.ctime;
            hanabi_obj0 = new GameObject[lon];
            hanabi_obj0 = wepon_player.getWeponHanabi(0);
            tama_obj0 = new Tama[lon][];
            tama_obj0 = wepon_player.getWeponTama(0);
           
        }
        // �E�E�E�N�E��E��E�b�E�N�E�p�E�̔��E�ˑ�̃X�E�N�E��E��E�v�E�g�E��E��E�擾
        if (hasydai_obj1 != null)
        {
            UnityEngine.Debug.Log(hasydai_obj1);
            hasyadai_script2 = hasydai_obj1.GetComponent<HasyadaiCOriginal>();
            ctime2 = hasyadai_script2.ctime;
            hanabi_obj1 = new GameObject[lon];
            hanabi_obj1 = wepon_player.getWeponHanabi(1);
            tama_obj1 = new Tama[lon][];
            tama_obj1 = wepon_player.getWeponTama(1);
        }
        UnityEngine.Debug.Log(ctime_image);
        UnityEngine.Debug.Log(ctime_image1);
        UnityEngine.Debug.Log(wepon_player.Hasyadai0);
        UnityEngine.Debug.Log(wepon_player.Hasyadai1);

        //�N�[���^�C�����m�F���邽�߂�obj�ɉ摜�f�[�^���擾
        //null�̏ꍇ�͕\���Ȃ�(�����ɂ���)
        if (wepon_player.Hasyadai0 != null)
        {
            ctime_image.sprite = wepon_player.Hasyadai0.itemImege;
            ctime_image.color = color_on;
        }
        else {
            ctime_image.sprite = null;
            ctime_image.color = color_off;
        }
        if (wepon_player.Hasyadai1 != null)
        {
            ctime_image1.sprite = wepon_player.Hasyadai1.itemImege;
            ctime_image1.color = color_on;
        }
        else
        {
            ctime_image1.sprite = null;
            ctime_image1.color = color_off;
        }


    }
    // Update�E�͖��E�t�E��E�{�E�[�E��E��E�Ă΂�郁E��\�E�b�E�h
    void Update()
    {
        if (debug)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack(id_hashadai, 0);
            }
            if (Input.GetMouseButtonDown(1))
            {
                attack(id_hashadai2, 1);
            }
        }
        if(!debug){ 
        // �E��E��E�N�E��E��E�b�E�N�E�p�E�̌��E�݂̃N�E�[�E��E��E�^�E�C�E��E��E��E��E�X�E�V
        tmp_ctime += Time.deltaTime;
        // �E��E��E�N�E��E��E�b�E�N�E��E��E��E��E��E��E��E�A�E�N�E�[�E��E��E�^�E�C�E��E��E��E��E�o�E�߂��E�Ă��E��E�ꍁE��ɍU�E��E�
        if (tmp_ctime > ctime)
        {

            if (Input.GetMouseButtonDown(0))
            {

                tmp_ctime = 0;
                attack(id_hashadai, 0);
            }
            if (ctime_image.sprite != null)
            {
                ctime_image.color = color_on;
            }
        }
        else
        {
            ctime_image.color = color_off;
        }


        // �E�E�E�N�E��E��E�b�E�N�E�p�E�̌��E�݂̃N�E�[�E��E��E�^�E�C�E��E��E��E��E�X�E�V
        tmp_ctime2 += Time.deltaTime;
        // �E�E�E�N�E��E��E�b�E�N�E��E��E��E��E��E��E��E�A�E�N�E�[�E��E��E�^�E�C�E��E��E��E��E�o�E�߂��E�Ă��E��E�ꍁE��ɍU�E��E�
        if (tmp_ctime2 > ctime2)
        {
            if (Input.GetMouseButtonDown(1))
            {
                tmp_ctime2 = 0;
                attack(id_hashadai2, 1);
            }

            if (ctime_image1.sprite != null)
            {
                ctime_image1.color = color_on;
            }
        }
        else
        {
            ctime_image1.color = color_off;
        }
    }
    }

    // �E��E��E�ˑ��E��E�C�E��E��E�X�E�^�E��E��E�X�E��E��E��E��E�A�E�U�E��E��E��E��E�J�E�n�E��E��E�郁E��\�E�b�E�h
    void attack(int id, int a)
    {
        Vector3 playerPosition = player.transform.position; // プレイヤーの現在の位置を取征E
        if (debug)
        {
            // �E��E��E�ˑ��E��E�v�E��E��E�C�E��E��E�[�E�̈ʒu�E�ɃC�E��E��E�X�E�^�E��E��E�X�E��E�
            //GameObject obj = Instantiate<GameObject>(hashadai[id], player.transform.position, Quaternion.identity);
            GameObject obj = Instantiate<GameObject>(hashadai[id], playerPosition, Quaternion.identity);
            // �E��E��E�ˑ�̃X�E�N�E��E��E�v�E�g�E��E��E�擾
            HasyadaiCOriginal script = obj.GetComponent<HasyadaiCOriginal>();
            // �E��E��E�ˑ�̃X�E�N�E��E��E�v�E�g�E�Ƀ}�E�l�E�[�E�W�E��E��E�[�E��E�ݒ�
            script.hasydai_manager = this;
            // �E��E��E�ˑ�̎��E��E�ID�E��E�ݒ�
            script.id_sikibetu = a;
        }
        else
        {
            GameObject obj=null;
         if (a==0&& hasydai_obj0!=null)    obj = Instantiate<GameObject>(hasydai_obj0, player.transform.position, Quaternion.identity);
          else if(a==1&&hasydai_obj1 != null)  obj = Instantiate<GameObject>(hasydai_obj1, player.transform.position, Quaternion.identity);
            // ���ˑ�̃X�N���v�g���擾
            if (obj == null) return;
             HasyadaiCOriginal script = obj.GetComponent<HasyadaiCOriginal>();
            // �E��E��E�ˑ�̃X�E�N�E��E��E�v�E�g�E�Ƀ}�E�l�E�[�E�W�E��E��E�[�E��E�ݒ�
            script.hasydai_manager = this;
            // �E��E��E�ˑ�̎��E��E�ID�E��E�ݒ�
            script.id_sikibetu = a;
        }
    }
}
