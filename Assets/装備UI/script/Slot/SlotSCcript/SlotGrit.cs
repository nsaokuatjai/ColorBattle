using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrit : MonoBehaviour
{

    [SerializeField]
    protected GameObject slotPrefab;
    public Item[] allItem;
    [SerializeField]
    protected int slotNumber = 20;
  //  [NonSerialized]
    public GameObject[] slot_obj;
    public GameManager gameManager;
    //�󂢂Ă�X���b�g�ɃA�C�e����ǉ����܂�
    public void addItem(Item item)
    {
        for (int i = 0; i < slotNumber; i++)
        {
//UnityEngine.Debug.Log("slot_obj[i]=" + slot_obj[i] + "i=" + i);
            if (slot_obj[i] == null) continue;
            Slot slot = slot_obj[i].GetComponent<Slot>();
           // UnityEngine.Debug.Log("slot_obj[i]="+ slot_obj[i]+"i="+i);
            if (slot.MyItem == null)
            {
          
                slot.SetItem(item);
                return;
            }
            
        }
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        slot_obj = new GameObject[slotNumber];
        for (int i = 0; i < slotNumber; i++)
        {
           
            GameObject slot_obj_tmp = Instantiate(slotPrefab, this.transform);
            slot_obj[i] = slot_obj_tmp;
            Slot slot = slot_obj_tmp.GetComponent<Slot>();

            //�f�o�b�O�p�ɃA�C�e�����_�X
        if(i<allItem.Length)
            {
                slot.SetItem(allItem[i]);
            }
            else
            {
                slot.SetItem(null);
            }
        }
    }
    void Update()
    {
  
        if (gameManager.item_list.Count != 0)
        {
            while (gameManager.item_list.Count > 0)
            {
                Item tmp_item = gameManager.item_list[0];
                addItem(tmp_item);
                gameManager.item_list.RemoveAt(0);
            }
        }
    }
}
