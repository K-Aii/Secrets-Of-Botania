using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InvSlot : MonoBehaviour, IPointerClickHandler
{
    public Sprite selectedSprite;
    public Sprite deselectedSprite;
    public Sprite activeSprite;
    Image UIimg;

    public Item cut;

    private void Awake()
    {
        Deselect();
        UIimg = GetComponent<Image>();
    }

    public void Select() //when clicked (use item) --> glowing sprite
    {
        GetComponent<Image>().sprite = selectedSprite;
    }

    public void Deselect() // normal beige
    {
        GetComponent<Image>().sprite = deselectedSprite;
    }

    public void Activate() //normal white
    {
        GetComponent<Image>().sprite = activeSprite;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        //ImageDOCrossfade.DOCrossfadeImage(UIimg, selectedSprite, 0.3f);
        //InvItem itemInSlot = GetComponentInChildren<InvItem>();
        //if (itemInSlot != null && itemInSlot.item == cut)
        //{
        //    PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        //    pc.Cut();
        //}
        StartCoroutine(Clicked());
        //if child Item = cut,then call playercontroller.cut()
        
    }

    IEnumerator Clicked()
    {
        

        
        Select();
        yield return new WaitForSeconds(1);
        Deselect();
    }
}
