using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy1 : Attck
{
    private void OnParticleCollision(GameObject other)
    {
       // UnityEngine.Debug.Log("aaaa");
        if (other.CompareTag("Player"))
        {
            
            UnityEngine.Debug.Log("aaaa");
            attack(other);
        }
    }
}