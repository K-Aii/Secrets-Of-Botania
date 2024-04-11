using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CraftButton : MonoBehaviour, IPointerClickHandler
{
    bool isOn = false;
    public CanvasGroup craft;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle() { 
        isOn = !isOn;

        if (isOn)
            craft.alpha = 1;
        else
            craft.alpha = 0;
    }

    public void OnPointerClick(PointerEventData eventData) {

        Toggle();
    }
}
