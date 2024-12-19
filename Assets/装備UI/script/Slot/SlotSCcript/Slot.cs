
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    protected Item item;
    private Extext text_ex;
    //ドラッグが用のオブジェクト
    protected GameObject dragging_obj;

    protected Hand hand;
    [SerializeField]
    protected UnityEngine.UI.Image item_image;
    [SerializeField]
    protected GameObject item_image_obj;
    [SerializeField]
    protected Vector3 scale;
    protected Transform canvasTransform;
    public Item MyItem {  get=>item; protected set=>item=value; }

    public virtual void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;

       hand = FindObjectOfType<Hand>();
        text_ex = FindObjectOfType<Extext>();

    }
    //itemを背っとする

    public virtual void SetItem(Item item)
    {
        MyItem = item;
        if (MyItem != null)
        {
            item_image.sprite = item.itemImege;
            item_image.color = new Color(1 ,1, 1, 1);
        }
        else
        {
            item_image.color = new Color(0,0,0,0);
        }
    }
    //ドラッグが始まるときの処理
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (MyItem==null) return;
        dragging_obj = Instantiate(item_image_obj, canvasTransform);
        dragging_obj.transform.localScale = scale;
     //オブジェクトを最前面に配置
        dragging_obj.transform.SetAsLastSibling();
        //複製元を黒くする
        item_image.color = Color.gray;
        //
        hand.setHandItem(MyItem);
         
    }
    //ドラッグ中の処理
    public virtual void OnDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        //ハンドの座標を負わせる
        dragging_obj.transform.position = hand.transform.position;
    }
    public virtual void OnDrop(PointerEventData eventData)
    {

        //違う武器が入るのを阻止
        if (hand.hasItem() == false) return;
        if (MyItem != null)
        {

            if (hand.setPlayerSlotBeginTriggerGet() && MyItem.wepon_id != hand.getItemNum()) return;
        }
        Item tmp = MyItem;
        SetItem(hand.getHandItem());

        hand.setHandItem(tmp);
        hand.setPlayerSlotBeginTriggeroff();
    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        SetItem(hand.getHandItem());
        Destroy(dragging_obj);
    }
    // マウスカーソルがオブジェクトに乗った時に呼ばれる
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MyItem == null) return;
        //説明文を表示させる
        text_ex.upText(MyItem);
    }

    // マウスカーソルがオブジェクトから離れた時に呼ばれる
    public void OnPointerExit(PointerEventData eventData)
    {
        text_ex.delText();
    }
}
