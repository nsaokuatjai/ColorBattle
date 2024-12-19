using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private bool on_ground;
    private bool on_jump=false;
    public bool isGround()
    {
        on_jump=true;
        return on_ground;
    }
   
    void OnTriggerStay2D(Collider2D other)
    {
       // UnityEngine.Debug.Log("afsdadd");
       if(on_jump)
        {
            on_jump = false;
            return;
        }
        if (other.CompareTag("field") || other.CompareTag("enemy"))
        {
            // UnityEngine.Debug.Log("afd");
           // UnityEngine.Debug.Log("432423");
            on_ground = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("field")|| other.CompareTag("enemy"))
        {
           // UnityEngine.Debug.Log("afd");

            on_ground = false;
        }
    }
}
