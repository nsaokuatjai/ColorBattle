using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerSlotGrit : MonoBehaviour
{
    //情報を管理するためのdata
    public struct data
    {
        public GameObject slot;
        public List<data> next;

        // コンストラクタ
        public data(GameObject a)
        {
            slot = a;
            next = new List<data>();
        }
    }
    public void initData(ref data tmp)
    {
        tmp.slot = null;
        tmp.next = new List<data>();
    }
     
    // 再帰的にすべてのslotを表示する関数
    public void DisplayAllSlots(data dataNode)
    {
        // 現在のノードのslotを表示
        if (dataNode.slot != null)
        {
          
            PlayerSlot playerSlot = dataNode.slot.GetComponent<PlayerSlot>();
        }

        // 次のノードがあれば再帰的に表示
        foreach (var nextNode in dataNode.next)
        {
            DisplayAllSlots(nextNode);
        }
    }
    //所持アイテムのスクリプト
    public SlotGrit slot_grit;
    private data hashadai = new data();
    [SerializeField]
    private GameObject[] slotPrefab;
    //スロットの位置の間隔
    [SerializeField]
    private float slot_point;
    //始めのスロットの位置
    [SerializeField]
    private Vector3 slot_offset;
    //登録している場所を指定する
    [SerializeField]
    private int player_equipment_id;
    private Player player;
    [SerializeField]
    private GameManager gameManager;
    private GameObject plaer_obj;
    HasydaiManager hasydaiManager;

    //発射台のスロット
    private　PlayerSlot  hasyadai_slot;

    void Start()
    {

        plaer_obj = gameManager.getplayer();
       hasydaiManager = plaer_obj.GetComponent<HasydaiManager>();
            player = new Player();
        GameObject slot_obj_tmp = Instantiate(slotPrefab[0], this.transform);
        PlayerSlot hasyadai_slot = slot_obj_tmp.GetComponent<PlayerSlot>();
        hasyadai_slot.playerSlotGrit = this;
        hasyadai_slot.SetItem(null);
        //発射台のスロットとして-2で識別できるように仕様
        hasyadai_slot.Slot_num_1 = -2;
        hasyadai_slot.Slot_num_2 = -2;
        initData(ref hashadai);
        hashadai.slot = slot_obj_tmp;
        DisplayAllSlots(hashadai);
        resetSlotPoint();


    }
    //スロットにデータを受け取りその分をdataに反映し適切にスロットを拡張する
    public void addSlot(Item tmp_item,int slot_num_1,int slot_num_2)
    {


        if (tmp_item.wepon_id==0)
        {
            //プレーヤーのデータをリセット
            player.hasyadaiReset(player_equipment_id);
            //スロットの配置をリセット
            resetNodes(hashadai);
            //プレイヤーにデータを背っと
            player.setWeponHasydai(player_equipment_id, tmp_item.ItemGet);
            //クールタイム用のitemを渡す
            if (player_equipment_id == 0) player.Hasyadai0 = tmp_item;
            if (player_equipment_id == 1) player.Hasyadai1 = tmp_item;
            //新しいスロットを作成
            for (int i = 0; i < tmp_item.getEquipmentNum(); i++)
            {
                //スロットの生成
                GameObject slot_obj_tmp = Instantiate(slotPrefab[1], this.transform);
                PlayerSlot slot = slot_obj_tmp.GetComponent<PlayerSlot>();
                slot.playerSlotGrit = this;
                //スロットに装備した場所を判定する番号を設定
                slot.Slot_num_1=i;
                //花火の場合は2は使わないのでー1に設定
                slot.Slot_num_2 = -1;
                //スロットのデータにノードを追加
                data tmp_data = new data(slot_obj_tmp);
                hashadai.next.Add(tmp_data);
            }

            DisplayAllSlots(hashadai);
            resetSlotPoint();
            hasydaiManager.resetWepon();
            
        }

        if(tmp_item.wepon_id==1)
        {//プレーヤーのデータをリセット
            player.hasyadaiReset(player_equipment_id, slot_num_1);
            //スロットの配置をリセット
            resetNodes(hashadai.next[slot_num_1]);
            player.setWeponHanabi(player_equipment_id, slot_num_1, tmp_item.ItemGet);
            for (int i = 0; i < tmp_item.getEquipmentNum(); i++)
            {
                //スロットの生成
                GameObject slot_obj_tmp = Instantiate(slotPrefab[2], this.transform);
                PlayerSlot slot = slot_obj_tmp.GetComponent<PlayerSlot>();
                slot.playerSlotGrit = this;
                //スロットに装備した場所を判定する番号を設定
                slot.Slot_num_1 = slot_num_1;
                slot.Slot_num_2 = i;
                //スロットのデータにノードを追加
                data tmp_data = new data(slot_obj_tmp);
                hashadai.next[slot_num_1].next.Add(tmp_data);
            }
            DisplayAllSlots(hashadai);
            resetSlotPoint();
            hasydaiManager.resetWepon();
        }
        if(tmp_item.wepon_id==2)
        {
            ItemTama tama = tmp_item as ItemTama;
            player.setWeponTama(player_equipment_id, slot_num_1,slot_num_2, tama.get_tama);
            DisplayAllSlots(hashadai);
            hasydaiManager.resetWepon();
        }

    }
    public void removeSlot(int slot_num_1, int slot_num_2)
    {   

        if (slot_num_1 == -2)
        {
            //プレーヤーのデータをリセット
            player.hasyadaiReset(player_equipment_id);
            //スロットの配置をリセット
            resetNodes(hashadai);
            if (player_equipment_id == 0) player.Hasyadai0 = null;
            if (player_equipment_id == 1) player.Hasyadai1 = null;
        }
        else if (slot_num_2 == -1)
        {
            player.hasyadaiReset(player_equipment_id, slot_num_1);
            resetNodes(hashadai.next[slot_num_1]);
            //スロットの配置をリセット
        }
        else
        {
            player. hasyadaiReset(player_equipment_id, slot_num_1, slot_num_2);
        }
        resetSlotPoint();
        hasydaiManager.resetWepon();


    }
    //引数ノード以降のノードを初期化しする
    public void resetNodes(data data_tmp)
    {
        if (data_tmp.slot == null) return;
        foreach (data node in data_tmp.next)
        {
            resetNodes(node); // 再帰的に次のノードを開放する
            Slot slot = node.slot.GetComponent<Slot>();
            if(slot!=null)  slot_grit.addItem(slot.MyItem);

            Destroy(node.slot);
        }
     
        data_tmp.next.Clear(); // Listをクリアしてメモリを開放
    }
    int count_reset;
    Vector3 pos;

    public void resetSlotPoint()
    { 
       count_reset = 0;
          resetSlotPoint(hashadai);
         
    }
    public void resetSlotPoint(data node)
    {


        // 現在のノードのslotを表示
        if (node.slot != null)
        {
            if (count_reset == 0) pos = slot_offset;
            PlayerSlot playerSlot = node.slot.GetComponent<PlayerSlot>();
            playerSlot.chengeRectTransfom(pos);
            count_reset++;
            pos.x += slot_point;
        }

        // 次のノードがあれば再帰的に表示
        foreach (var nextNode in node.next)
        {
            resetSlotPoint(nextNode);
                }
    }
}
