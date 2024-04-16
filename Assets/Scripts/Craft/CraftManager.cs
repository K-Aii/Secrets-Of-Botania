using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    public Image img1, img2, newSkillimg;
    public TextMeshProUGUI skillName;

    public Item one,two, r;

    public List<Recipe> recipes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Craft(Item a , Item b)
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            ShowPage(one, two, r);
        }
    }

    public void ShowPage(Item first, Item second, Item result) {
        InventoryManager inv = GetComponent<InventoryManager>();

        bool item1, item2, res;
        item1 = inv.SearchItem(first) != null;
        item2 = inv.SearchItem(second) != null;
        res = inv.SearchItem(result) == null;
        //print(item1); print(item2); print(res);

        if (item1 && item2 && res)
        {       //match --> show craft
            GameObject.Find("Book_base").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("Book_no").GetComponent<CanvasGroup>().alpha = 0;
            img1.sprite = first.img;
            img2.sprite = second.img;
            newSkillimg.sprite = result.img;
            skillName.text = result.name;
        }
        else 
        {
            GameObject.Find("Book_base").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Book_no").GetComponent<CanvasGroup>().alpha = 1;
        }

    }
}
