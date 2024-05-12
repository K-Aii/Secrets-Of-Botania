using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Sprite selectedSprite;
    public Sprite deselectedSprite;
    BlackFade fade;


    private void Awake()
    {
        Deselect();
        fade = FindObjectOfType<BlackFade>();

        if (fade.GetComponent<Image>().color.a == 1)
            StartCoroutine(fade.FadeIn(1f));

        if (GameObject.Find("Craft") != null) {
            Destroy(GameObject.Find("Canvas"));    
        }
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
