using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    [SerializeField]
    private GameObject player_obj;
    private GameObject player;
    public GameObject getplayer()
    {
        return player;
    }
    //�Q�[���I�[�o�[�̎��\������
    public GameObject game_over_obj;
    //�Q�[���N���A�̎��ɕ\������
    public GameObject game_clear_obj;
    //�A�b�v�O���[�h��\������
    public GameObject upgread_obj;
    //������ʂ��J�����\������
    public GameObject eqipment_yes_no_obj;

    //�������
    public GameObject eqipument_obj;
    //�n�߂̔\�̓A�b�v�̑I���̉��
    public GameObject start_nouryokuup;
    //�\�̓A�b�v�X���b�g�X�^�[�g
    [SerializeField]
    private GameObject[] nouryoku_obj_start;
    [SerializeField]
    private Floor floor;
    //�o�����Ă���G���Ǘ�
    private GameObject[] gameObject;
    //���݂̃X�e�[�W���������������Ǘ�����
    private int stage=0;
    private int i;
    [SerializeField]
    ItemManeger item_maneger;
    //�\�̓A�b�v�X���b�g
    [SerializeField]
    private GameObject[] nouryoku_obj;
    //update���ꎞ�I�Ɏ~�߂�֐�
    private bool stopupdate = false;
    //�\�̓A�b�v�̈ꎞ�ۑ����X�g
   �@public List<Item> item_list = new List<Item>();
    //���̃Q�[���ɂ���
    public bool nouryokuup_next=false;
    public bool next_game;
    public bool start_time;
    //�\�̓A�b�v�̉�
    public int nouryokuup_num=-1;
    //�ŏ��̔\�̓A�b�v�̉񐔂̍ő�l
    public int nouryokuup_num_max;
    public GameObject SoundManeger;
    SoundManager soundManager;
    public GameObject ctime_obj;
    public GameObject ctime_obj2;

    HasydaiManager hasydaiManager;
    void Awake()
    {   //�v���[���[�̐���
        player = Instantiate<GameObject>(player_obj, offset, Quaternion.identity);
        hasydaiManager = player.GetComponent<HasydaiManager>();
        hasydaiManager.Ctime_obj=ctime_obj;
        hasydaiManager.Ctime_obj2=ctime_obj2;
        stage = 0;
        gameObject = new GameObject[floor.max];
        eqipument_obj.transform.localScale = new Vector3(0,0,0);
        start_time=true;

    }
    void Start()
    {
        nouryokuup_next = true;
        nouryokuup_num = -1;
        soundManager = SoundManeger.GetComponent<SoundManager>();
        soundManager.PlayBGM(3);
    }
    //�G�𐶐������肷��
    void startFloor()
    {
        soundManager.PlayBGM(3);
        DestroyEnemiesWithTag("enemywepon");
        DestroyEnemiesWithTag("playerwepon");
        DestroyEnemiesWithTag("enemy");
        int floor_id;
        int randomInt;
        if (stage < 3)
        {//�ニ�[�v

             randomInt = UnityEngine.Random.Range(0, 6);
            gameObject = floor.create(randomInt);

        }
        else if (stage == 3)
        {
            gameObject = floor.create(6);
        }
        else if(stage < 7)
        {
            randomInt = UnityEngine.Random.Range(7, 12);
            gameObject = floor.create(randomInt);
        }
        else if (stage == 7)
        {
            randomInt = UnityEngine.Random.Range(12, 14);
            gameObject = floor.create(randomInt);
        }
        //�G��������������֐����g��
        stage++;
    }
    void DestroyEnemiesWithTag(string tag)
    {
        // �w�肳�ꂽ�^�O�����S�Ă�GameObject���擾
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        // �擾����GameObject��S�Ĕj��
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
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
        DestroyEnemiesWithTag("enemywepon");
        DestroyEnemiesWithTag("playerwepon");
        DestroyEnemiesWithTag("enemy");
        soundManager.PlayBGM(1);
        stopupdate = true;
        game_clear_obj.SetActive(true);
        upgread_obj.SetActive(true);
        eqipment_yes_no_obj.SetActive(false);
        addNouryoku();

            //�Ƃ肠�����������ł���悤�ɂ���
        /*�A�b�v�O���[�h��\������������������
            �\�����������̂��N���b�N���ꂽ�狭���𔽉f������
        �A�b�v�O���[�h���Ǘ�����N���X�����
        ������ʂ̏I�����܂��͑��������Ȃ������ꍇstartfloor�Ŏ��̃t���A���n�߂�
        */
    }
    // Update is called once per frame
    void Update()
    {
        if (eqipument_obj.transform.localScale.x == 0)
        {
            eqipument_obj.transform.localScale = new Vector3(1, 1, 0);
            eqipument_obj.SetActive(false);
        }
        if (start_time)
        {
            if (nouryokuup_next)
            {
                nouryokuup_num++;
            }
            if (nouryokuup_num == nouryokuup_num_max)
            {
                start_nouryokuup.SetActive(false);
                eqipument_obj.SetActive(true);
                nouryokuup_next = false;
                start_time = false;
                game_clear_obj.SetActive(false);
                stopupdate = true;
                return;
            }
            if (nouryokuup_num % 3 == 0 && nouryokuup_next)
            {
                start_nouryokuup.SetActive(true);
                stratAddNouryoku(0);
            }
            if (nouryokuup_num % 3 == 1 && nouryokuup_next)
            {
                start_nouryokuup.SetActive(true);
                stratAddNouryoku(1);
            }
            if (nouryokuup_num % 3 == 2 && nouryokuup_next)
            {
                start_nouryokuup.SetActive(true);
                stratAddNouryoku(2);
            }
            game_clear_obj.SetActive(false);
            
            nouryokuup_next = false;
        }
        if (start_time) return;
         if (nouryokuup_next && start_time == false)
        {
            upgread_obj.SetActive(false);
            eqipment_yes_no_obj.SetActive(true);
            nouryokuup_next = false;
        }
        if (next_game&& stage!=8)
        {
            upgread_obj.SetActive(false);
            eqipment_yes_no_obj.SetActive(false);
            eqipument_obj.SetActive(false);
            next_game = false;
            player.transform.position = offset;
            stopupdate = false;
            startFloor();
        }
        else if(next_game && stage == 8)
        {
            //�{�X��̏���
            SceneManager.LoadScene("demothukan");
        }

        if (stopupdate) return;

        if (player == null)
        {    //�v���C���[�����񂾎��̏���
            playerDie();
        }
        else
        {
            i = 0;
            foreach(var obj in gameObject)
            {   
                if (obj != null) break;
                i++;
            }
            if(i==floor.max)clearFlooer();
        }

    }
    //�\�̓A�b�v��\�̓A�b�v�X���b�g�ɔ��f������
    //����̂�
    Item item;
    int ransuint;

    public GameObject Player { get => player; set => player = value; }
    public GameObject Player1 { get => player; set => player = value; }
    //�n�܂�̔\�̓A�b�v�̏���
    void stratAddNouryoku(int id)
    {
       

        WeponManeger[] wm = item_maneger.wepon_maneger;
        int[] randomIntlist = new int[nouryoku_obj_start.Length]; 
        foreach (var obj in nouryoku_obj_start)
        {
            nouryokuupslot slot = obj.GetComponent<nouryokuupslot>();
            if (id==0)
            {

                ransuint = UnityEngine.Random.Range(0, wm[0].length());            
                item = wm[0].Item(ransuint);
            }
           else if (id==1)
            {

                ransuint = UnityEngine.Random.Range(0, wm[1].length());
                item = wm[1].Item(ransuint);
            }
            else if(id==2)  
            {

                ransuint = UnityEngine.Random.Range(0, wm[2].length());
                item = wm[2].Item(ransuint);
            }
            slot.SetItem(item);
        }
    }
    void addNouryoku()
    {
        int randomInt;
        WeponManeger[] wm = item_maneger.wepon_maneger;
        foreach (var obj in nouryoku_obj)
        {
            nouryokuupslot slot = obj.GetComponent<nouryokuupslot>();
            randomInt = UnityEngine.Random.Range(0, 5);

            if (randomInt == 0)
            {
               
                randomInt = UnityEngine.Random.Range(0, wm[0].length());
                 item= wm[0].Item(randomInt);
            }
            if (randomInt == 1||randomInt==2)
            {

                randomInt = UnityEngine.Random.Range(0, wm[1].length());
                 item = wm[1].Item(randomInt);
            }
            if (randomInt == 3 || randomInt == 4)
            {

                randomInt = UnityEngine.Random.Range(0, wm[2].length());
                 item = wm[2].Item(randomInt);
            }
            slot.SetItem(item);
        }

    }
}
