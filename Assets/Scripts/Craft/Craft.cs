using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public Item test;
    public AudioClip success;

    public void Create() {
        //craft click > add new skill with audio > close craft ui auto > alert new skill slot 

        //CraftManager manager = GameObject.Find("GameController").GetComponent<CraftManager>();
        StartCoroutine(Flow());

    }

    public IEnumerator Flow(){
        InventoryManager inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
        inv.AddItem(test);
        GetComponent<AudioSource>().PlayOneShot(success);
        GameObject.Find("CraftButton").GetComponent<CraftButton>().Toggle();
        inv.SearchItem(test).Activate();
        yield return new WaitForSeconds(1);
        inv.SearchItem(test).Deselect();
    }
}
