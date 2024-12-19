using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Floor1[] c;
    public GameObject[] d;
    public int max = 5;
    public GameObject[] create(int id){
        d = new GameObject[5];
        int i = 0;
    foreach(var item in c[id].a)
{
    d[i] = Instantiate<GameObject>(item, c[id].b[i], Quaternion.identity);
    i++;
}

        return d;
    }

}
