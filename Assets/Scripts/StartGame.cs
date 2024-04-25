using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Sprite selectedSprite;
    public Sprite deselectedSprite;

    private void Awake()
    {
        Deselect();
    }

    public void Select() 
    {
        GetComponent<SpriteRenderer>().sprite = selectedSprite;
    }

    public void Deselect() 
    {
        GetComponent<SpriteRenderer>().sprite = deselectedSprite;
    }

    private void OnMouseEnter()
    {
        Select();
    }

    private void OnMouseExit()
    {
        Deselect();
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);   
    }
}
