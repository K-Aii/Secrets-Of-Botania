using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InvSlot : MonoBehaviour
{
    public Sprite selectedSprite;
    public Sprite deselectedSprite;
    public Sprite activeSprite;

    private void Awake()
    {
        Deselect();
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

}
