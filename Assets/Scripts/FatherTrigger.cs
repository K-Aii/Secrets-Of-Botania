using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FatherTrigger : MonoBehaviour
{
    public AudioClip door;
    GameObject NPC, playerDialogue;
    Canvas NPCdialogue;
    bool isOut = false;
    int dialogueIndex = 0;
    public Item cut;
    InventoryManager inv;

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.Find("Father");
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
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "ARE YOU REALLY GOING?";
                break;
            case 3:
                playerDialogue.GetComponent<Dialogue>().left = false;
                playerDialogue.GetComponent<Canvas>().enabled = true;
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "ADVENTURE IS CALLING ME!";
                break;
            case 4:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "THEN BRING THIS WITH YOU";
                break;
            case 5:
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "THANK YOU!";
                break;
            case 6:
                playerDialogue.GetComponent<Canvas>().enabled = false;
                if (isOut)
                {
                    NPC.GetComponent<Animator>().SetTrigger("back");
                    //GetComponent<AudioSource>().PlayOneShot(door);
                    //NPC.GetComponent<BoxCollider2D>().enabled = false;
                    isOut = false;
                }

                if (inv.SearchItem(cut) == null)
                {
                    inv.AddItem(cut);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (NPC.transform.position.z > -1)
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
