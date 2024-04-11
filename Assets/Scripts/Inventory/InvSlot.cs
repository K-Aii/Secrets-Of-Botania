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
    [SerializeField]Image UIimg;

    public Item cut;

    private void Awake()
    {
        Deselect();
        //UIimg = GetComponent<Image>();
    }

    public void Select() //when clicked (use item) --> glowing sprite
    {
        UIimg.sprite = selectedSprite;
    }

    public void Deselect() // normal beige
    {
        UIimg.sprite = deselectedSprite;
    }

    public void Activate() //normal white
    {
        UIimg.sprite = activeSprite;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        //ImageDOCrossfade.DOCrossfadeImage(UIimg, selectedSprite, 0.3f);

        //StartCoroutine(Clicked());

    }

    //IEnumerator Clicked()
    //{
    //    Select();
    //    yield return new WaitForSeconds(1);
    //    Deselect();
    //}
}
