using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InvSlot[] invSlots;
    public GameObject itemPrefab;
    public InvSlot graySlot;

    int selectedSlot = -1; //none, 0-4

    public Item test;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            AddItem(test);
            //NewSkill(test);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log(SearchItem(test));
            
        }


    }

    void ChangeSelected(int newSlot) {
        if (selectedSlot >= 0) {
            invSlots[selectedSlot].Deselect(); //deselect current slot
        }

        invSlots[newSlot].Select();
        selectedSlot = newSlot;
    }
    
    public void AddItem(Item item) {       // add item into inv
        for (int i = 0; i < invSlots.Length; i++)
        {
            InvItem itemInSlot = invSlots[i].GetComponentInChildren<InvItem>();
            if (itemInSlot == null) {         //loop through array search for empty slot(=without child)
                SpawnItem(item, invSlots[i]);
                return;
            }
        }
    }

    public InvSlot SearchItem(Item item) {
        for (int i = 0; i < invSlots.Length; i++)
        {
            InvItem itemInSlot = invSlots[i].GetComponentInChildren<InvItem>();
            if (itemInSlot != null && itemInSlot.item == item) { 
                return invSlots[i];
            }
        }
        return null;
    }

    public void ShowObtainableSkill(Item item) {
        SpawnItem(item, graySlot);
    }

    void SpawnItem(Item item, InvSlot slot) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);   //generate new item prefab with slot as parent 
        InvItem invItem = newItem.GetComponent<InvItem>();
        invItem.InitialiseItem(item);       //get script in newly created item prefab and initialise
    }
    
}
