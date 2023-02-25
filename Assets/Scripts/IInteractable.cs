using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(InteractionData interactionData);
}

public class InteractionData
{
    public InventorySlot currentInventorySlot;
    // public Inventory inventory;

    public InteractionData(InventorySlot currentInventorySlot/*, Inventory inventory*/)
    {
        this.currentInventorySlot = currentInventorySlot;
        // this.inventory = inventory;
    }
}