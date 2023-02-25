using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(InteractionData interactionData);
}

public class InteractionData
{
    public ItemScriptableObject heldItem;
    // public Inventory inventory;

    public InteractionData(ItemScriptableObject heldItem/*, Inventory inventory*/)
    {
        this.heldItem = heldItem;
        // this.inventory = inventory;
    }
}