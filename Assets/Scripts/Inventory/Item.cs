using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public Sprite img;
}

public enum ItemType { 
    Skill,
    Potion
}

