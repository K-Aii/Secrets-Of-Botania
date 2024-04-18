using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendTransition : MonoBehaviour
{
    SpriteRenderer icon;
    GameObject player;
    bool stay;

    // Start is called before the first frame update
    void Start()
    {
        //icon = GameObject.Find("shift").GetComponent<SpriteRenderer>();
        icon = transform.GetChild(0).GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (stay) {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(this.name == "tree03")
                    player.transform.position = new Vector3(37f, 2.5f, 0);
                else if (this.name == "tree06")
                    player.transform.position = new Vector3(27.5f, -1.25f, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            icon.enabled = true;
            stay = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            icon.enabled = false;
            stay = false;
        }
    }
}
