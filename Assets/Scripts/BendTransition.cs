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
        icon = GameObject.Find("shift").GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (stay) {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                player.transform.position = new Vector3(37f, 2.5f, 0);
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
