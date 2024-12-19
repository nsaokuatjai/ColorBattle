using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 5)]

public abstract class Item :  ScriptableObject
{
    public abstract int wepon_id { get; }
    public string exText { get => ex_text; }
    public Sprite itemImege { get => item_imege; }
    public GameObject ItemGet { get => item;}
    public string Name { get => name;}
    //”­Ë‘ä‚Æ‰Ô‰Î‚Ì‘•”õ‰Â”\”‚ğæ“¾
    public int getEquipmentNum()
    {
        HasyadaiCOriginal script = item.GetComponent<HasyadaiCOriginal>();
        if(script != null)return script.equipment_hanabi_num;
        HanabiManegerOriginal script_1 = item.GetComponent<HanabiManegerOriginal>();
        if(script_1 != null)return script_1.equipment_tama_num;
            return -1;
    }
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Sprite item_imege;
    [SerializeField]
    private string ex_text;
    [SerializeField]
    private string name;
}
