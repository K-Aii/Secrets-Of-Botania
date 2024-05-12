using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sing : MonoBehaviour
{
    bool move, isEffective = false;
    AudioSource audioSource;
    public AudioClip mermaid;

    Canvas NPCdialogue;
    int dialogueIndex = 0;
    public Item potion;
    InventoryManager inv;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        NPCdialogue = GameObject.Find("NPC_Dialogue").GetComponent<Canvas>();
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(71.5f, -0.2f, 0);
        if (move) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos , 2 * Time.deltaTime);
        }
        if (transform.position == targetPos) {
            move = false;
        }

        if (NPCdialogue.enabled)
            if (Input.GetMouseButtonDown(0))
                dialogueIndex++;

        switch (dialogueIndex)
        {
            case 1:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "For you, my dear!";
                break;
            case 2:
                NPCdialogue.GetComponentInChildren<TextMeshProUGUI>().text = "GOOD LUCK!";
                break;
            case 3:
                NPCdialogue.enabled = false;
                if (inv.SearchItem(potion) == null)
                {
                    inv.AddItem(potion);
                }
                break;
        }
    }

    public void SingToNPC() {
        audioSource.PlayOneShot(mermaid);
        if (isEffective)
        {
            this.GetComponent<MobController>().enabled = false;
            transform.localScale = new Vector3(-1, 1, 1);
            move = true;
            NPCdialogue.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            isEffective = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            isEffective = false;
        }
    }
}
