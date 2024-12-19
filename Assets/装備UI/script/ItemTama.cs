using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "tama", menuName = "tama", order = 5)]

public class ItemTama :  Item
{
    [SerializeField]
    private Tama tama;
    public override int wepon_id { get=> 2; }
    public Tama get_tama { get => tama;}
}
