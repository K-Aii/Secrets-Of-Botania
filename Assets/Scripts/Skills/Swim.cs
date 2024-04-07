using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    bool stay;
    bool found = false;
    Canvas dialogue;
    SpriteRenderer player;
    public AudioClip find, ding;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("Dialogue").GetComponent<Canvas>();
        player = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stay) {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !found) {
                StartCoroutine(Find());
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
        GetComponent<SpriteRenderer>().enabled = true;
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
