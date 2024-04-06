using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InvItem : MonoBehaviour, IPointerClickHandler
{
    public Item item;

    [Header("Skills")]
    public Item cut;


    public void InitialiseItem(Item newitem) {
        item = newitem;
        GetComponent<Image>().sprite = newitem.img;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //    //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        InvItem itemInSlot = GetComponentInChildren<InvItem>();
        if (itemInSlot != null && itemInSlot.item == cut)
        {
            PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            pc.Cut();
        }

    }


}
