using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptableObject : ScriptableObject
{
    public string name;
    public string description;
    public int maxInventoryStack;
    public Sprite inventoryIcon;
    public float inventoryIconScale = 1;
    public Category category;
    public ItemType itemType;

    private Collider2D collider;
    private void Awake()
    {
        collider.isTrigger = true;
    }

    public enum Category
    {
        None,
        Plant,
        HarvestedPlant,
        Tool
    }

    public enum ItemType
    {
        TomatoSeed,
        Tomato,
        Axe
    }
}
