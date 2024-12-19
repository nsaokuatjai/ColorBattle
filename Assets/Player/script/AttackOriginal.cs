using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackOriginal : MonoBehaviour
{
    [SerializeField]
    public byte r;
    [SerializeField]
    public byte g;
    [SerializeField]

    public byte b;
    //攻撃するときの処理
    protected abstract void attack(GameObject other);
    //親クラスのメソッドはbase.メソッド名で呼べる
    //攻撃の倍率を定義
    [System.NonSerialized]
    public float power;

}
