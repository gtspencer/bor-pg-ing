using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Obsolete]
public class InventoryItemSlotPresentation : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private Text countText;
    private ItemScriptableObject slottedItem;

    public bool isOccupied
    {
        get => slottedItem != null;
    }
    
    public int itemCount;
    public int maxStack;

    private void Start()
    {
        UpdatePresentation();
    }

    public void SlotItem(ItemScriptableObject slottedItem, int amount)
    {
        this.slottedItem = slottedItem;
        maxStack = slottedItem.maxInventoryStack;
        itemCount = amount;
        UpdatePresentation();
        itemSprite.sprite = slottedItem.inventoryIcon;
    }

    public ItemScriptableObject GetSlottedItem()
    {
        return slottedItem;
    }

    public void RemoveSlottedItem()
    {
        slottedItem = null;
        itemCount = 0;
        maxStack = 0;
        
        UpdatePresentation();
    }
    
    public void AddAmount(int amount)
    {
        if (itemCount + amount > maxStack)
            return;
        
        itemCount += amount;

        UpdatePresentation();
    }
    
    public void RemoveItem()
    {
        if (itemCount == 1)
        {
            itemCount--;
            RemoveSlottedItem();
            return;
        }

        itemCount--;

        UpdatePresentation();
    }

    private void UpdatePresentation()
    {
        countText.text = itemCount.ToString();

        if (!isOccupied && itemSprite.enabled)
        {
            itemSprite.enabled = false;
        }
        else if (isOccupied && !itemSprite.enabled)
        {
            itemSprite.enabled = true;
        }
    }
}
