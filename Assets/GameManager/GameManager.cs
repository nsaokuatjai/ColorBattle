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
    //ゲームオーバーの時表示する
    public GameObject game_over_obj;
    //ゲームクリアの時に表示する
    public GameObject game_clear_obj;
    //アップグレードを表示する
    public GameObject upgread_obj;
    //装備画面を開くか表示する
    public GameObject eqipment_yes_no_obj;

    //装備画面
    public GameObject eqipument_obj;
    //始めの能力アップの選択の画面
    public GameObject start_nouryokuup;
    //能力アップスロットスタート
    [SerializeField]
    private GameObject[] nouryoku_obj_start;
    [SerializeField]
    private Floor floor;
    //出現している敵を管理
    private GameObject[] gameObject;
    //現在のステージが何回やったかを管理する
    private int stage=0;
    private int i;
    [SerializeField]
    ItemManeger item_maneger;
    //能力アップスロット
    [SerializeField]
    private GameObject[] nouryoku_obj;
    //updateを一時的に止める関数
    private bool stopupdate = false;
    //能力アップの一時保存リスト
   　public List<Item> item_list = new List<Item>();
    //次のゲームにする
    public bool nouryokuup_next=false;
    public bool next_game;
    public bool start_time;
    //能力アップの回数
    public int nouryokuup_num=-1;
    //最初の能力アップの回数の最大値
    public int nouryokuup_num_max;
    public GameObject SoundManeger;
    SoundManager soundManager;
    public GameObject ctime_obj;
    public GameObject ctime_obj2;

    HasydaiManager hasydaiManager;
    void Awake()
    {   //プレーヤーの生成
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
    //敵を生成したりする
    void startFloor()
    {
        soundManager.PlayBGM(3);
        DestroyEnemiesWithTag("enemywepon");
        DestroyEnemiesWithTag("playerwepon");
        DestroyEnemiesWithTag("enemy");
        int floor_id;
        int randomInt;
        if (stage < 3)
        {//弱ループ

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
        //敵をせいせいする関数を使う
        stage++;
    }
    void DestroyEnemiesWithTag(string tag)
    {
        // 指定されたタグを持つ全てのGameObjectを取得
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        // 取得したGameObjectを全て破壊
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
    }

    //プレイヤーが死んだ時の処理
    void playerDie()
    {
        game_over_obj.SetActive(true);
        stopupdate=true;
    }

    //フロアクリアの処理
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

            //とりあえず装備をできるようにする
        /*アップグレードを表示させル処理を書く
            表示させたものがクリックされたら強化を反映させる
        アップグレードを管理するクラスも作る
        装備画面の終了時または装備をしなかった場合startfloorで次のフロアを始める
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
            //ボス戦の処理
            SceneManager.LoadScene("demothukan");
        }

        if (stopupdate) return;

        if (player == null)
        {    //プレイヤーが死んだ時の処理
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
    //能力アップを能力アップスロットに反映させる
    //武器のみ
    Item item;
    int ransuint;

    public GameObject Player { get => player; set => player = value; }
    public GameObject Player1 { get => player; set => player = value; }
    //始まりの能力アップの処理
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
