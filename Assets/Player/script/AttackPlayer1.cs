using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class AttackPlayerUIDemo : Attck
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("enemy"))
        {
            attack(other);
        }
    }
    protected override void attack(GameObject other)
    {
        power = 1;
        //  UnityEngine.Debug.Log("eleer");
        Damege dam = other.GetComponent<Damege>();
        //エラーチェック
        if (dam != null)
        {
            UnityEngine.Debug.Log(r + "," + b + "," + g + "power=" + power);
            byte tmp_r = (byte)(r * power);
            byte tmp_g = (byte)(g * power);
            byte tmp_b = (byte)(b * power);
            dam.damegeColor(tmp_r, tmp_g, tmp_b);
        }
    }

}