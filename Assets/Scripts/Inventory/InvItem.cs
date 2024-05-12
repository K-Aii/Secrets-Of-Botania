using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;


public class InvItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public AudioClip success;

    public Transform parentAfterDrag;


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

    IEnumerator Consume() {
        yield return new WaitForSeconds(1.2f);
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject);
        InventoryManager invManager = GameObject.Find("GameController").GetComponent<InventoryManager>();
        InvItem itemInSlot = GetComponent<InvItem>();
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        GameObject.Find("ItemName_text").GetComponent<TextMeshProUGUI>().text = item.name;
        GameObject.Find("ItemContent_text").GetComponent<TextMeshProUGUI>().text = item.description;
        if (invManager.CheckInMain(itemInSlot.item))
            return;
        GetComponentInParent<InvSlot>().StartCoroutine(Clicked());

        //Skill --> Cut
        if (itemInSlot != null && itemInSlot.item.name == "Cut")
            pc.Cut();


        //Skill --> Jump
        if (itemInSlot != null && itemInSlot.item.name == "Jump")
            pc.Jump();

        //Skill --> Swim
        if (itemInSlot != null && itemInSlot.item.name == "Swim") {
            if (SceneManager.GetActiveScene().name == "003_Lake")
                pc.Swim();
            else
                print("Not in water");
        }   

        //Skill --> Waterjet
        if (itemInSlot != null && itemInSlot.item.name == "WaterJet")
            StartCoroutine(pc.Jet());

        //Potion --> Pacify
        if (itemInSlot != null && itemInSlot.item.name == "Pacify") {
            if (GameObject.Find("notes") != null)
            {
                FindObjectOfType<SirenSing>().Pacify();
                StartCoroutine(Consume());
            }
            else
                print("Not used");
        }

        //if parent is graySlot --> add new skill
        GameObject clickedItem = eventData.pointerCurrentRaycast.gameObject;
        if (clickedItem.transform.parent.tag == "graySlot")
        {
            invManager.AddItem(clickedItem.GetComponent<InvItem>().item);   //obtain new skill (add into inv)
            GameObject.Find("Inventory").GetComponent<AudioSource>().PlayOneShot(success);
            GameObject.Find("new Slot_BG").GetComponent<CanvasGroup>().alpha = 0;   //unshow new skill notify slot

            //check recipe --> show and alert if new
            CraftManager craftManager = GameObject.Find("GameController").GetComponent<CraftManager>();
            craftManager.ShowForSkill(clickedItem.GetComponent<InvItem>().item);
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
        GetComponent<Image>().raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    void IDragHandler.OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData) {
        GetComponent<Image>().raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

}
