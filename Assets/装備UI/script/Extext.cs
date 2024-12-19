using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System;

public class Extext : MonoBehaviour
{ //TextMeshPro uiText;
    string text;
    string enter = "\n";
    public TextMeshProUGUI uiText;
    public TextMeshProUGUI uiText2;
    public GameObject hand;
    public GameObject childObject;
    public Vector3 offset;
    public GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = offset;
        if (hand.gameObject.GetComponent<RectTransform>().anchoredPosition.x > 0) tmp.x *= -1;
        if (hand.gameObject.GetComponent<RectTransform>().anchoredPosition.y > 0) tmp.y *= -1;
       // UnityEngine.Debug.Log(tmp + "hand=" + hand.gameObject.GetComponent<RectTransform>().anchoredPosition);
        tmp.x*=canvas.transform.localScale.x;
        tmp.y *= canvas.transform.localScale.y;
        childObject.transform.position = hand.gameObject.transform.position + tmp;
    }
    public void upText(Item item)
    {
        childObject.SetActive(true);
        uiText.text = item.exText;
        uiText2.text = item.Name;
        uiText2.text += "  ";
        if(item.wepon_id==0)
        {
            uiText2.text += "”­ŽË‘ä";
        }
        if (item.wepon_id == 1)
        {
            uiText2.text += "‰Ô‰Î";
        }
        if (item.wepon_id == 2)
        {
            uiText2.text += "’e";
        }

    }

    public void delText()
    {
        childObject.SetActive(false);

    }
}
