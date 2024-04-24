using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MapUIButton : MonoBehaviour, IPointerClickHandler
{
    bool isOn = false;
    public CanvasGroup map;
    
    public void Toggle() { 
        isOn = !isOn;

        if (isOn)
            map.alpha = 1;
        else
            map.alpha = 0;
    }

    public void OnPointerClick(PointerEventData eventData) {

        Toggle();
    }
}
