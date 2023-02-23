using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // items and their counts
    private Dictionary<ItemScriptableObject.ItemType, int> inventoryItems;

    [SerializeField] private HotBarSlotItem[] hotBarSlots;

    private HotBarSlotItem currentSelected;

    private void Start()
    {
        inventoryItems = new Dictionary<ItemScriptableObject.ItemType, int>();
        currentSelected = hotBarSlots[0];
        currentSelected.SetSelected();
    }

    private void Update()
    {
        // TODO maybe move this to character controller
        ProcesPlayerInputs();
    }

    private void SetSelected(int index)
    {
        currentSelected.SetUnselected();
            
        currentSelected = hotBarSlots[index];
        currentSelected.SetSelected();
    }

    private void ProcesPlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSelected(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSelected(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSelected(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSelected(3);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSelected(4);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetSelected(5);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetSelected(6);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetSelected(7);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetSelected(8);
        }
    }

    private void Awake()
    {
        inventoryItems = new Dictionary<ItemScriptableObject.ItemType, int>();
    }

    public void AddItem(ItemScriptableObject item)
    {
        if (inventoryItems.ContainsKey(item.itemType))
        {
            inventoryItems[item.itemType]++;
            UpdateInventoryUI(item);
        }
        else
        {
            AddNewItem(item);
            UpdateInventoryUI(item, true);
        }
    }

    private void UpdateInventoryUI(ItemScriptableObject item, bool newItem = false)
    {
        if (newItem)
        {
            foreach (HotBarSlotItem slotItem in hotBarSlots)
            {
                if (!slotItem.inventoryItemPresentation.isOccupied)
                {
                    slotItem.inventoryItemPresentation.SlotItem(item);
                    return;
                }
            }
        }
        
        foreach (HotBarSlotItem slotItem in hotBarSlots)
        {
            if (slotItem.inventoryItemPresentation.GetSlottedItem() == item)
            {
                slotItem.inventoryItemPresentation.AddItem();
                return;
            }
        }
    }

    public bool CanPickupItem(ItemScriptableObject item)
    {
        /*bool roomAvailable = false;
        foreach (HotBarSlotItem slotItem in hotBarSlots)
        {
            if (slotItem.inventoryItem == item && slotItem.count < slotItem.inventoryItem.maxStack)
                return true;

            if (!slotItem.occupied)
                return true;
        }*/
        
        return true;
    }

    private void AddNewItem(ItemScriptableObject item)
    {
        inventoryItems[item.itemType] = 1;
    }

    public void RemoveItem(ItemScriptableObject item)
    {
        if (!inventoryItems.ContainsKey(item.itemType))
            return;

        inventoryItems[item.itemType]--;
    }
    
}
