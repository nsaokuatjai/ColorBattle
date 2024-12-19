using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanabiOriginal : MonoBehaviour
{
    //攻撃の倍率を定義
    public float power;
    //装備する弾の数を管理
    public int tama_num;
    //弾を管理する数
    public TamaOriginal tama;
    //破壊するかを確認するフラグ
    protected bool isRmain = false;
    //発射する数を管理
    public int attack_num;
    //発射間隔を管理
    public float attack_rate;

}
