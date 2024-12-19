using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemM", menuName = "ItemM", order = 5)]
public class ItemManeger : ScriptableObject
{
    [SerializeField]
    private WeponManeger[] weponManeger;

    public WeponManeger[] wepon_maneger { get => weponManeger; }
}
