using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public Sprite img;
    [TextArea(4, 10)]
    public string description;
}

public enum ItemType { 
    Skill,
    Potion,
    Item
}

