using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Inventory")]
public class InventoryScriptableObject : ScriptableObject
{
    public InventorySlot[] Container = new InventorySlot[24];
    public Action OnInventoryChanged = () => { };

    public bool AddItem(ItemScriptableObject item, int amount)
    {
        for (int i = 0; i < Container.Length; i++)
        {
            // TODO add amount up to maxAmount, then overflow in to next slot
            if (Container[i].item == item && Container[i].amount + amount <= Container[i].maxAmount)
            {
                Container[i].AddAmount(amount);
                OnInventoryChanged.Invoke();
                return true;
            }
        }

        var slot = SetFirstEmptySlot(item, amount);

        if (slot == null)
            return false;

        // TODO modify for full inventory
        OnInventoryChanged?.Invoke();
        return true;
    }

    public void MoveItems(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.item, item2.amount);
        item2.UpdateSlot(item1.item, item1.amount);

        item1.UpdateSlot(temp.item, temp.amount);
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(ItemScriptableObject item, int amount)
    {
        for (int i = 0; i < Container.Length; i++)
        {
            if (Container[i].item == item)
            {
                if (Container[i].amount == amount)
                    Container[i].UpdateSlot(null, 0);
                else
                    Container[i].UpdateSlot(item, Container[i].amount - amount);
            }
        }
        OnInventoryChanged?.Invoke();
    }

    public InventorySlot SetFirstEmptySlot(ItemScriptableObject item, int amount)
    {
        for (int i = 0; i < Container.Length; i++)
        {
            if (Container[i].item == null)
            {
                Container[i].UpdateSlot(item, amount);
                return Container[i];
            }
        }
        // TODO inventory full
        return null;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemScriptableObject item;
    public int amount;
    public int maxAmount => item.maxInventoryStack;

    public InventorySlot(ItemScriptableObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }

    public void UpdateSlot(ItemScriptableObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
