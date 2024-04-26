using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drown : MonoBehaviour
{
    PlayerController player;
    InventoryManager inv;
    public Item swim;
    AudioSource audioSource;
    public AudioClip noti;
    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Bubbles(Clone)") == null)
        {
            if (inv.SearchItem(swim).gameObject.GetComponent<Image>().sprite != inv.SearchItem(swim).activeSprite)
            {
                inv.SearchItem(swim).Activate();
                audioSource.PlayOneShot(noti);
            }
            if(!started)
                StartCoroutine(Timer());
        }
        else {
            started = false;
            StopAllCoroutines();
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }

    }
    IEnumerator Timer() {
        started = true;
        float currentTime = 0;
        while (currentTime < 7f)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(0, 0.4f, currentTime / 7f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, newA);
            yield return null;
        }
        player.Die();
        yield return new WaitForSeconds(1);
        started = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        StopAllCoroutines();
    }
}
