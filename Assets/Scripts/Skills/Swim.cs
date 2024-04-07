using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    bool stay;
    bool found = false;
    Canvas dialogue;
    SpriteRenderer player, show;

    public AudioClip find, ding;
    AudioSource audioSource;
    
    CanvasGroup newSkill;
    InventoryManager inv;
    public Item swimSkill;
    
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("Dialogue").GetComponent<Canvas>();
        player = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        newSkill = GameObject.Find("new Slot_BG").GetComponent<CanvasGroup>();
        show = GetComponent<SpriteRenderer>();
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (stay)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !found)
            {
                StartCoroutine(Find());
            }

            if (show.enabled)
            {
                newSkill.alpha = 1;
                //create new child if don hv
                InvItem skillInSlot = inv.graySlot.GetComponentInChildren<InvItem>();
                if (skillInSlot == null)
                {
                    //print("t");
                    inv.NewSkill(swimSkill);
                }

            }
        }
        else {
            if (show.enabled)
            {
                newSkill.alpha = 0;
                //destory child if have
                InvItem skillInSlot = inv.graySlot.GetComponentInChildren<InvItem>();
                if (skillInSlot != null)
                {
                    Destroy(skillInSlot.gameObject);
                }

            }
        }

    }

    IEnumerator Find() {
        dialogue.enabled = false;
        yield return new WaitForSeconds(1f);
        player.sortingOrder = -1;
        audioSource.PlayOneShot(find);
        yield return new WaitForSeconds(2f);
        player.sortingOrder = 2;
        show.enabled = true;
        found = true;
        audioSource.PlayOneShot(ding);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            if (!found)
                dialogue.enabled = true;
            stay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(!found)
                dialogue.enabled = false;
            stay = false;
        }
       
    }


}
