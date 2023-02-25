using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    // items and their counts
    [SerializeField]
    private InventoryScriptableObject inventory;

    [SerializeField] private HotBarSlotItem[] hotBarSlots;

    private HotBarSlotItem currentSlotSelected;

    public HotBarSlotItem CurrentSelected
    {
        get => currentSlotSelected;
    }

    private void Start()
    {
        currentSlotSelected = hotBarSlots[0];
        currentSlotSelected.SetSelected();
    }

    private void Update()
    {
        // TODO maybe move this to character controller
        ProcesPlayerInputs();
    }

    private void SetSelected(int index)
    {
        currentSlotSelected.SetUnselected();
            
        currentSlotSelected = hotBarSlots[index];
        currentSlotSelected.SetSelected();
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
        
    }

    // returns if the add item was successful
    public bool AddItem(ItemScriptableObject item, int amount)
    {
        return inventory.AddItem(item, amount);
    }

    private void UpdateInventoryUI(ItemScriptableObject item, int amount, bool newItem = false)
    {
        if (newItem)
        {
            foreach (HotBarSlotItem slotItem in hotBarSlots)
            {
                if (!slotItem.inventoryItemPresentation.isOccupied)
                {
                    slotItem.inventoryItemPresentation.SlotItem(item, amount);
                    return;
                }
            }
        }
        
        foreach (HotBarSlotItem slotItem in hotBarSlots)
        {
            if (slotItem.inventoryItemPresentation.GetSlottedItem() == item)
            {
                slotItem.inventoryItemPresentation.AddAmount(amount);
                return;
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container = new InventorySlot[24];
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

    /*private void AddNewItem(ItemScriptableObject item, int amount)
    {
        inventoryItems[item.itemType] = amount;
    }

    public void RemoveItem(ItemScriptableObject item)
    {
        if (!inventoryItems.ContainsKey(item.itemType))
            return;

        inventoryItems[item.itemType]--;
        UpdateInventoryUI(item, inventoryItems[item.itemType]);
    }*/
    
}
