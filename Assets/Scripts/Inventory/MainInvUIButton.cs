using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MainInvUIButton : MonoBehaviour, IPointerClickHandler
{
    bool isOn = false;
    public CanvasGroup main;

    public void Toggle()
    {
        isOn = !isOn;

        if (isOn)
        {
            main.alpha = 1;
            main.blocksRaycasts = true;
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            main.alpha = 0;
            main.blocksRaycasts = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Toggle();
    }
}