using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(InteractionData interactionData);
}

public class InteractionData
{
    public InventorySlot heldItem;
    // public Inventory inventory;

    public InteractionData(InventorySlot heldItem/*, Inventory inventory*/)
    {
        this.heldItem = heldItem;
        // this.inventory = inventory;
    }
}