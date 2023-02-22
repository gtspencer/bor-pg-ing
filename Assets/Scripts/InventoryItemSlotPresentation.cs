using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotPresentation : MonoBehaviour
{
    [SerializeField] private Text countText;
    public ItemScriptableObject slottedItem;
    
    public int itemCount;
    public int maxStack;

    public void SlotItem(ItemScriptableObject slottedItem)
    {
        this.slottedItem = slottedItem;
        maxStack = slottedItem.maxInventoryStack;
        itemCount = 0;
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
