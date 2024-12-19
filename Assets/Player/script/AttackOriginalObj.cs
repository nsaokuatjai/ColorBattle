using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackOriginalObj : AttackOriginal
{
     private GameObject obj;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        obj = gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color32(r, g, b, 255);
    }
    protected override abstract void attack(GameObject other);
}
