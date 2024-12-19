using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Wepon", menuName = "Wepon", order = 5)]

public class WeponManeger : ScriptableObject
{
    [SerializeField]
    private Item[] item;

    public Item Item(int id)
    {
       return item[id]; 
    }
    public int length()
    {
        return  item.Length;
}
}
