
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "弾", menuName = "弾", order = 5)]

public class Tama : ScriptableObject
{
    public string dataName;
    public byte r;
    public byte g;
    public byte b;
    //0は能力なし1は色がランダム

    public int[] abi;
}
