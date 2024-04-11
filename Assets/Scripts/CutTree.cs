using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    GameObject player;
    bool stay;
    InventoryManager inv;
    public Item requiredSkill;
    public bool collide = false;

    // Start is called before the first frame update
    void Start()
    {
        //icon = GameObject.Find("shift").GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
     //   Debug.Log(transform.localRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (stay)
        {
            if (!collide)
            {
                Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            }

            

            //if click skill --> @skill script --> detect collide with tree --> tree down --> enable box collision with player
        }
        else {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            stay = true;
            if (inv.SearchItem(requiredSkill) != null)
            {
                inv.SearchItem(requiredSkill).Activate();
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stay = false;
            if (inv.SearchItem(requiredSkill) != null)
            {
                inv.SearchItem(requiredSkill).Deselect();
            }
        }
    }


}
