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
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Are you sure about the adventure?";
                break;
            case 3:
                playerDialogue.GetComponent<Dialogue>().left = false;
                playerDialogue.GetComponent<Canvas>().enabled = true;
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Absolutely!\nI am pumped!";
                break;
            case 4:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Take this with you,";
                break;
            case 5:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "it¡¦ll be your ally!";
                break;
            case 6:
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Wow! Thank you, Father!";
                if (inv.SearchItem(cut) == null)
                {
                    inv.AddItem(cut);
                }
                break;
            case 7:
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Father, is there anything you want?";
                break;
            case 8:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Hmmm¡K";
                break;
            case 9:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Just bring me a flower from each place.";
                break;
            case 10:
                playerDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Sure! Goodbye, Father!";
                break;
            case 11:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Believe in yourself!";
                break;
            case 12:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Enjoy the adventure!";
                break;
            case 13:
                playerDialogue.GetComponent<Canvas>().enabled = false;
                if (isOut)
                {
                    NPC.GetComponent<Animator>().SetTrigger("back");
                    //GetComponent<AudioSource>().PlayOneShot(door);
                    //NPC.GetComponent<BoxCollider2D>().enabled = false;
                    isOut = false;
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
