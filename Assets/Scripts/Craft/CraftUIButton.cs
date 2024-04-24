using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CraftUIButton : MonoBehaviour, IPointerClickHandler
{
    bool isOn = false;
    public CanvasGroup craft;
    
    public void Toggle() { 
        isOn = !isOn;

        if (isOn)
        {
            craft.alpha = 1;
            craft.blocksRaycasts = true;
        }

        else
        {
            craft.alpha = 0;
            craft.blocksRaycasts = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {

        Toggle();
    }
}
