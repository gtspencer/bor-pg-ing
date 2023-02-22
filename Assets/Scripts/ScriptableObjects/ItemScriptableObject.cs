using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    public string name;
    public string description;
    public Sprite inventoryIcon;
    public ItemType itemType;

    public enum ItemType
    {
        None,
        Plant,
    }
}
