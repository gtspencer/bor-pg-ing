using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemScriptableObject : ScriptableObject
{
    public string name;
    public string description;
    public int maxInventoryStack;
    public Sprite inventoryIcon;
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
        HarvestedPlant
    }

    public enum ItemType
    {
        TomatoSeed,
        Tomato,
    }
}
