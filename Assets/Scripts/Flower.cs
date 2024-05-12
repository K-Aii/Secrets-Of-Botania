using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flower : MonoBehaviour
{
    Transform octopus;
    bool stay = false;
    InventoryManager inv;
    public Item flower;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "003_Lake")
            octopus = GameObject.Find("Octopus (2)").GetComponent<Transform>();
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (octopus)
            transform.position = new Vector3(octopus.position.x + 0.7f, octopus.position.y + 0.2f, transform.position.z);
        else {
            GetComponent<Rigidbody2D>().simulated = true;
        }

        if (stay) {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (inv.SearchItem(flower) == null)
                {
                    inv.AddItem(flower);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stay = true;
            if (transform.childCount != 0)
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stay = false;
        if (transform.childCount != 0)
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }


}
