using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Item hand_item;
    private bool player_slot_bigin_torgger=false;
    void Update()
    {
     //   UnityEngine.Debug.Log(hand_item);

        this.transform.position = Input.mousePosition;
    }
    public Item getHandItem()
    {
        Item old_item=hand_item;
        hand_item=null;
        return old_item;
    }
    public Item getHandItem2()
    {
        Item old_item = hand_item;
        return old_item;
    }
    public void setHandItem(Item item)
    {
        hand_item=item;
    }
    public bool hasItem()
    {
        return hand_item!=null;
    }
    //¡‚Á‚Ä‚¢‚éƒAƒCƒeƒ€‚Ì”Ô†‚ğ•Ô‚·
    public int getItemNum()
    {
        if (hand_item == null) return -1;
        return hand_item.wepon_id;
    }
    public void setPlayerSlotBeginTrigger()
    {
        player_slot_bigin_torgger = true;
    }
    public void setPlayerSlotBeginTriggeroff()
    {
        player_slot_bigin_torgger = false;
    }
    public bool setPlayerSlotBeginTriggerGet()
    {
        return player_slot_bigin_torgger;
    }
}
