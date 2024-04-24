using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InvItem : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public AudioClip success;


    public void InitialiseItem(Item newitem)
    {
        item = newitem;
        GetComponent<Image>().sprite = newitem.img;
    }

    IEnumerator Clicked()
    {
        InvSlot slot = GetComponentInParent<InvSlot>();
        slot.Select();
        yield return new WaitForSeconds(1);
        slot.Deselect();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject);
        GetComponentInParent<InvSlot>().StartCoroutine(Clicked());

        //Skill --> Cut
        InvItem itemInSlot = GetComponent<InvItem>();
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (itemInSlot != null && itemInSlot.item.name == "Cut")
            pc.Cut();


        //Skill --> Jump
        if (itemInSlot != null && itemInSlot.item.name == "Jump")
            pc.Jump();

        //if parent is graySlot --> add new skill
        GameObject clickedItem = eventData.pointerCurrentRaycast.gameObject;
        if (clickedItem.transform.parent.tag == "graySlot")
        {
            GameObject.Find("GameController").GetComponent<InventoryManager>().AddItem(clickedItem.GetComponent<InvItem>().item);   //obtain new skill (add into inv)
            GameObject.Find("Inventory").GetComponent<AudioSource>().PlayOneShot(success);
            GameObject.Find("new Slot_BG").GetComponent<CanvasGroup>().alpha = 0;   //unshow new skill notify slot
            GameObject.Find("swimSkill").GetComponent<SpriteRenderer>().enabled = false;    //unshow skill obtaining obj

            //check recipe --> show and alert if new
            CraftManager craftManager = GameObject.Find("GameController").GetComponent<CraftManager>();
            craftManager.ShowForSkill(clickedItem.GetComponent<InvItem>().item);
        }
    }


}
