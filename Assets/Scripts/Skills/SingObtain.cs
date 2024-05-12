using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingObtain : MonoBehaviour
{
    bool stay;
    SpriteRenderer show;

    CanvasGroup newSkill;
    InventoryManager inv;
    public Item singSkill;


    // Start is called before the first frame update
    void Start()
    {
        newSkill = GameObject.Find("new Slot_BG").GetComponent<CanvasGroup>();
        show = GetComponent<SpriteRenderer>();
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (show.enabled && stay)
        {
            newSkill.alpha = 1;
            //create new child if don hv
            InvItem skillInSlot = inv.graySlot.GetComponentInChildren<InvItem>();
            if (skillInSlot == null)
            {
                inv.ShowObtainableSkill(singSkill);
            }

        }
        else if (!show.enabled || !stay) 
        { 
            newSkill.alpha = 0;
            //destory child if have
            InvItem skillInSlot = inv.graySlot.GetComponentInChildren<InvItem>();
            if (skillInSlot != null)
            {
                Destroy(skillInSlot.gameObject);
            }

        }
        
        if (inv.SearchItem(singSkill) != null)
        {
            show.enabled = false;    //unshow skill obtaining obj
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            stay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stay = false;
        }

    }


}
