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
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject);

        InvItem itemInSlot = GetComponentInChildren<InvItem>();
        if (itemInSlot != null && itemInSlot.item == cut)
        {
            PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            pc.Cut();
        }

        //if parent is graySlot --> add new skill
        GameObject clickedItem = eventData.pointerCurrentRaycast.gameObject;
        if (clickedItem.transform.parent.tag == "graySlot") {
            GameObject.Find("GameController").GetComponent<InventoryManager>().AddItem(clickedItem.GetComponent<InvItem>().item);   //obtain new skill (add into inv)
            GameObject.Find("new Slot_BG").GetComponent<CanvasGroup>().alpha = 0;   //unshow new skill notify slot
            GameObject.Find("swimSkill").GetComponent<SpriteRenderer>().enabled = false;    //unshow skill obtaining obj


        }
    }


}
