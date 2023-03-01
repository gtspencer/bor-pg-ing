using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    // items and their counts
    [SerializeField]
    private InventoryScriptableObject inventory;

    [SerializeField] private HotBarSlotDisplay[] hotBarSlots;

    private HotBarSlotDisplay currentHotBarSlot;

    public InventorySlot CurrentSelectedSlot
    {
        get => currentHotBarSlot.HeldSlot;
    }

    private void Start()
    {
        inventory.SetupCallbacks();
        
        currentHotBarSlot = hotBarSlots[0];
        currentHotBarSlot.SetSelected();
    }

    private void Update()
    {
        // TODO maybe move this to character controller
        ProcesPlayerInputs();
    }

    private void SetSelected(int index)
    {
        currentHotBarSlot.SetUnselected();
            
        currentHotBarSlot = hotBarSlots[index];
        currentHotBarSlot.SetSelected();
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

    // returns if the add item was successful
    public bool AddItem(ItemScriptableObject item, int amount)
    {
        return inventory.AddItem(item, amount);
    }

    public void DropItem(ItemScriptableObject item, int amount)
    {
        inventory.RemoveItem(item, amount);
        var droppedItem = new GameObject();
        var pickupItem = droppedItem.AddComponent<PickUpItem>();

        pickupItem.PlacePickupItem(item, amount);

        droppedItem.transform.position = transform.position;
    }

    private void OnApplicationQuit()
    {
        inventory.Container = new InventorySlot[40];
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
