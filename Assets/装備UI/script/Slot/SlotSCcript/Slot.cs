
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    protected Item item;
    private Extext text_ex;
    //�h���b�O���p�̃I�u�W�F�N�g
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
    //item��w���Ƃ���

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
    //�h���b�O���n�܂�Ƃ��̏���
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (MyItem==null) return;
        dragging_obj = Instantiate(item_image_obj, canvasTransform);
        dragging_obj.transform.localScale = scale;
     //�I�u�W�F�N�g���őO�ʂɔz�u
        dragging_obj.transform.SetAsLastSibling();
        //����������������
        item_image.color = Color.gray;
        //
        hand.setHandItem(MyItem);
         
    }
    //�h���b�O���̏���
    public virtual void OnDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        //�n���h�̍��W�𕉂킹��
        dragging_obj.transform.position = hand.transform.position;
    }
    public virtual void OnDrop(PointerEventData eventData)
    {

        //�Ⴄ���킪����̂�j�~
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
    // �}�E�X�J�[�\�����I�u�W�F�N�g�ɏ�������ɌĂ΂��
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MyItem == null) return;
        //��������\��������
        text_ex.upText(MyItem);
    }

    // �}�E�X�J�[�\�����I�u�W�F�N�g���痣�ꂽ���ɌĂ΂��
    public void OnPointerExit(PointerEventData eventData)
    {
        text_ex.delText();
    }
}
