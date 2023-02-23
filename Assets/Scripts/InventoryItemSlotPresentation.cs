using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotPresentation : MonoBehaviour
{
    [SerializeField] private RawImage itemSprite;
    [SerializeField] private Text countText;
    private ItemScriptableObject slottedItem;

    public bool isOccupied
    {
        get => slottedItem != null;
    }
    
    public int itemCount;
    public int maxStack;

    public void SlotItem(ItemScriptableObject slottedItem)
    {
        this.slottedItem = slottedItem;
        maxStack = slottedItem.maxInventoryStack;
        itemCount = 0;
        UpdateCountText();
        itemSprite.texture = slottedItem.inventoryIcon.texture;
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
        
        UpdateCountText();
    }
    
    public void AddItem()
    {
        if (itemCount >= maxStack)
            return;
        
        itemCount++;

        UpdateCountText();
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

        UpdateCountText();
    }

    private void UpdateCountText()
    {
        countText.text = itemCount.ToString();
    }
}
