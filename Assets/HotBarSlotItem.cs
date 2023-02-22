using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// different ui to display inventory item slot presentation item
public class HotBarSlotItem : MonoBehaviour
{
    [SerializeField] private RawImage selectedBox;
    [SerializeField] private RawImage itemSprite;
    [SerializeField] private RawImage countText;

    private InventoryItemSlotPresentation inventoryItem;
    // Start is called before the first frame update
    void Awake()
    {
        selectedBox.enabled = false;

        if (inventoryItem == null)
            itemSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(InventoryItemSlotPresentation inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        itemSprite.enabled = true;
        itemSprite.texture = inventoryItem.slottedItem.inventoryIcon.texture;
    }

    public void SetSelected()
    {
        selectedBox.enabled = true;
    }

    public void SetUnselected()
    {
        selectedBox.enabled = false;
    }
}
