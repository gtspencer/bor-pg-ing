using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Inventory")]
public class InventoryScriptableObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <param name="amount"></param>
    /// <returns>
    /// Whether or not the time was added
    /// This will only return false if the inventory is full
    /// </returns>
    public bool AddItem(ItemScriptableObject item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            // TODO add amount up to maxAmount, then overflow in to next slot
            if (Container[i].item == item && Container[i].amount + amount <= Container[i].maxAmount)
            {
                Container[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Container.Add(new InventorySlot(item, amount));
        }

        /*if (Container.ContainsKey(item.itemType))
        {
            // chec if over max amount
            // maybe make the values in the dict a list of inventory slots?
            // or maybe our keys are our inventory slots and we loop over?
            Container[item.itemType].AddAmount(amount);
            return true;
        }
        else
        {
            Container[item.itemType] = new InventorySlot(item, amount);
            return true;
        }*/
        
        // TODO modify for full inventory
        return true;
    }

    public void RemoveItem(ItemScriptableObject item, int amount)
    {
        
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
}
