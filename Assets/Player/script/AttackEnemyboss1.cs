using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyboss1 : Attck
{
    public float attack_power;
    void Start()
    {
        base.Start();

    }
    protected override void attack(GameObject other)
    {
        //  UnityEngine.Debug.Log("eleer");
        Damege dam = other.GetComponent<Damege>();
        //エラーチェック
        if (dam != null)
        {
            byte tmp_r = (byte)(r * attack_power);
            byte tmp_g = (byte)(g * attack_power);
            byte tmp_b = (byte)(b * attack_power);
            dam.damegeColor(tmp_r, tmp_g, tmp_b);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
       // UnityEngine.Debug.Log("aaaa");
        if (other.CompareTag("Player"))
        {
            
            UnityEngine.Debug.Log("aaaa");
            attack(other);
            Destroy(gameObject);
        }
    }
}