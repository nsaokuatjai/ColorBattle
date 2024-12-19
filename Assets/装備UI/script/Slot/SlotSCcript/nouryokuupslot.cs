
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

public class nouryokuupslot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    protected Item item;
    private Extext text_ex;
    protected Hand hand;
    [SerializeField]
    protected UnityEngine.UI.Image item_image;
    protected Transform canvasTransform;
    [SerializeField]
    private GameManager gameManager;
    public SoundManager soundManager;
    public int slot_num;
    public Item MyItem {  get=>item; protected set=>item=value; }

    public virtual void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;
        GameManager gameManager = FindObjectOfType<GameManager>();
        hand = FindObjectOfType<Hand>();
        text_ex = FindObjectOfType<Extext>();

    }
    //itemを背っとする
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            soundManager.PlaySE(SoundManager.SE_TYPE.ACTION, 0);
            // 左クリック時の処理
            text_ex.delText();
            gameManager.item_list.Add(MyItem);
            gameManager.nouryokuup_next = true;
        }
    }

    public  void SetItem(Item item)
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
    // マウスカーソルがオブジェクトに乗った時に呼ばれる
    public void OnPointerEnter(PointerEventData eventData)
    {
       // UnityEngine.Debug.Log("myitem="+MyItem);
        if (MyItem == null) return;
        text_ex.upText(MyItem);
    }

    // マウスカーソルがオブジェクトから離れた時に呼ばれる
    public void OnPointerExit(PointerEventData eventData)
    {
       // UnityEngine.Debug.Log("myitemasdf" + MyItem);
        text_ex.delText();
    }
}
