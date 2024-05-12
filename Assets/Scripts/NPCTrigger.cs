using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NPCTrigger : MonoBehaviour
{
    public AudioClip door;
    GameObject NPC, playerDialogue;
    Canvas NPCdialogue;
    bool isOut = false;
    int dialogueIndex = 0;
    public Item potion;
    InventoryManager inv;
    
    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.Find("NPC");
        NPCdialogue = NPC.GetComponentInChildren<Canvas>();
        playerDialogue = GameObject.Find("Dialogue");
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCdialogue.enabled)
            if (Input.GetMouseButtonDown(0))
                dialogueIndex++;

        switch (dialogueIndex)
        {
            case 2:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Where are\nyou off to?";
                break;
            case 3:
                playerDialogue.GetComponent<Dialogue>().left = false;
                playerDialogue.GetComponent<Canvas>().enabled = true;
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "I AM HEADING WEST!";
                break;
            case 4:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "That's brave of you!";
                break;
            case 5:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Take this potion,";
                break;
            case 6:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "it will help you on your journey!";
                break;
            case 7:
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "THANK YOU!";
                break;
            case 8:
                playerDialogue.GetComponent<Canvas>().enabled = false;
                if (isOut)
                {
                    NPC.GetComponent<Animator>().SetTrigger("back");
                    //GetComponent<AudioSource>().PlayOneShot(door);
                    NPC.GetComponent<BoxCollider2D>().enabled = false;
                    isOut = false;
                }

                if (inv.SearchItem(potion) == null)
                {
                    inv.AddItem(potion);
                }
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            if(NPC.transform.position.z > -1)
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (!isOut)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            NPC.GetComponent<Animator>().enabled = true;
            dialogueIndex++;
            GetComponent<AudioSource>().PlayOneShot(door);
            isOut = true;
        }
    }
}
