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
    //�U������Ƃ��̏���
    protected abstract void attack(GameObject other);
    //�e�N���X�̃��\�b�h��base.���\�b�h���ŌĂׂ�
    //�U���̔{�����`
    [System.NonSerialized]
    public float power;

}
