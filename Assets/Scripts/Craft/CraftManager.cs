using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    public Image img1, img2, newSkillimg;
    public Sprite btnAlertIcon, btnDefaultIcon;
    public TextMeshProUGUI skillName;
    Item resultant;

    public List<Recipe> recipes;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var recipe in recipes)
        {
            ShowPage(recipe.a, recipe.b, recipe.result);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowForSkill(Item skill) {  //check all recipes and show match page
        foreach (var recipe in recipes)
        {
            if (recipe.a == skill || recipe.b == skill)
                ShowPage(recipe.a, recipe.b, recipe.result);

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
            GameObject.Find("CraftButton").GetComponent<Image>().sprite = btnAlertIcon;
            img1.sprite = first.img;
            img2.sprite = second.img;
            newSkillimg.sprite = result.img;
            skillName.text = result.name;
            resultant = result;
        }
        else 
        {
            GameObject.Find("Book_base").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Book_no").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("CraftButton").GetComponent<Image>().sprite = btnDefaultIcon;
        }

    }

    public void Craft()
    {
        InventoryManager inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
        inv.AddItem(resultant);
        //update book page + check if any other craftable
        foreach (var recipe in recipes)
        {
            ShowPage(recipe.a, recipe.b, recipe.result);
        }
        //close ui auto
        GameObject.Find("CraftButton").GetComponent<CraftUIButton>().Toggle();
    }
}
