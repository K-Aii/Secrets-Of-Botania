using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNotify : MonoBehaviour
{
    InventoryManager inv;
    public Item jump;
    public AudioClip noti;
    AudioSource audioSourcce;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
        audioSourcce = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (inv.SearchItem(jump) != null)
            {
                inv.SearchItem(jump).Activate();
                audioSourcce.PlayOneShot(noti);
            }
            
            if(transform.childCount != 0)
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

            

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (inv.SearchItem(jump) != null)
            {
                inv.SearchItem(jump).Deselect();
            }
            
            if (transform.childCount != 0)
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
