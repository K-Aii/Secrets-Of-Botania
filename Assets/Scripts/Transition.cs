using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Transition : MonoBehaviour
{
    public int nextLevel;
    BlackFade fade;
    bool stay;

    public Item flower;
    Canvas playerDialogue;
    public AudioClip denial;

    //public static Transition instance;

    public void Awake()
    {
        fade = FindObjectOfType<BlackFade>();
        stay = false;

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(GameObject.Find("Canvas"));
        //}
        //else
        //{
        //    Destroy(GameObject.Find("Canvas"));
        //}

        playerDialogue = GameObject.Find("Dialogue").GetComponent<Canvas>();

        if (fade.GetComponent<Image>().color.a == 1)
            StartCoroutine(fade.FadeIn(1f));
    }

    private void Update()
    {
        if (fade.completed)
        {
            if(stay)
                SceneManager.LoadScene(nextLevel);
        }
    }


    //public void NextLevel() {
    //    StartCoroutine(LoadLevel());
    //}

    //IEnumerator LoadLevel() {
    //    yield return new WaitForSeconds(2);
    //    SceneManager.LoadSceneAsync(nextLevel);

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            stay = true;

            //check flower
            if (FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>().SearchItem(flower) != null)
                StartCoroutine(fade.FadeOut(1f));
            else {
                print("No flower");
                GameObject.Find("Canvas").GetComponent<AudioSource>().PlayOneShot(denial);
                playerDialogue = GameObject.Find("Dialogue").GetComponent<Canvas>();
                playerDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "I NEED THE FLOWER!";
                playerDialogue.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerDialogue.enabled) {
            playerDialogue.enabled = false;
        }
    }


}
