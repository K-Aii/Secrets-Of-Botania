using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvItem : MonoBehaviour
{
    public Item item;
    public void InitialiseItem(Item newitem) {
        item = newitem;
        GetComponent<Image>().sprite = newitem.img;
    }
}
