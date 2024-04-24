using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MapLoadScene : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.gameObject.name == "Home_btn")
            SceneManager.LoadScene(0);
        

        if (this.gameObject.name == "Forest_btn")
            SceneManager.LoadScene(1);

        FindObjectOfType<MapUIButton>().Toggle();
    }
}
