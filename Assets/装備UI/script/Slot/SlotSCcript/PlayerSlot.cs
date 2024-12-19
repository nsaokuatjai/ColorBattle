
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;

public class PlayerSlot : Slot
{

    public Item MyItem {  get=>item; private set=>item=value; }
    public int Slot_num_1 { get => slot_num_1; set => slot_num_1 = value; }
    public int Slot_num_2 { get => slot_num_2; set => slot_num_2 = value; }

    //弾2花火1発射台0で管理する
    [SerializeField]
    private int  wepon_num;
    private int  slot_num_1;
    private int  slot_num_2;
    public PlayerSlotGrit playerSlotGrit;
   
  
    public void chengeRectTransfom(Vector3 pos)
    {
       
        gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
         //  UnityEngine.Debug.Log("pos=" + pos+"\nslotnum1="+slot_num_1+"\nslotnum2="+slot_num_2+"transform"+ gameObject.GetComponent<RectTransform>().anchoredPosition);
      
    }
    public override void Start()
    {
       
        base.Start();
        SetItem(null);
        UnityEngine.UI. Image image_tmp = gameObject.GetComponent < UnityEngine.UI.Image >();

        if(wepon_num==0)image_tmp.color =  new Color32(255, 200, 200,255);
        if (wepon_num == 1) image_tmp.color = new Color32(200, 255, 200,255);
        if (wepon_num == 2) image_tmp .color = new Color32(200, 200, 255,255);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {//
        UnityEngine.Debug.Log("start drag");
        // UnityEngine.Debug.Log("ドラッグ開始");
        if (MyItem == null) return;
        dragging_obj = Instantiate(item_image_obj, canvasTransform);
        //オブジェクトを最前面に配置
        dragging_obj.transform.SetAsLastSibling();
        //大きさをそろえる
        dragging_obj.transform.localScale = scale;
        //複製元を黒くする
        item_image.color = Color.gray;
        //
        hand.setHandItem(MyItem);
        //違う武器が入れないようにする
        hand.setPlayerSlotBeginTrigger();
        UnityEngine.Debug.Log("end start drag");

    }
    public override void OnDrop(PointerEventData eventData)
    {

      //  UnityEngine.Debug.Log("hand.getItemNum()="+ hand.getItemNum());
        if(hand.hasItem() == null||wepon_num!=hand.getItemNum()|| hand.getHandItem2()==MyItem) return;

        Item tmp = MyItem;
        SetItem(hand.getHandItem());
          hand.setHandItem(tmp);
        playerSlotGrit.addSlot(MyItem, slot_num_1,  slot_num_2);
        hand.setPlayerSlotBeginTriggeroff();
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        if (hand.setPlayerSlotBeginTriggerGet()) {
            SetItem(hand.getHandItem());
            hand.setPlayerSlotBeginTriggeroff();
            Destroy(dragging_obj);
            return; 
        }
        SetItem(hand.getHandItem());
       if(MyItem==null) playerSlotGrit. removeSlot(slot_num_1, slot_num_2);
        else playerSlotGrit.addSlot(MyItem, slot_num_1, slot_num_2);
        Destroy(dragging_obj);
        hand.setPlayerSlotBeginTriggeroff();
    }
}
