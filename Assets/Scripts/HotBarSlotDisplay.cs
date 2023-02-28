using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// different ui to display inventory item slot presentation item
public class HotBarSlotDisplay : InventorySlotDisplay
{
    [SerializeField] private RawImage selectedBox;
    private InventorySlot heldSlot;

    // Start is called before the first frame update
    void Awake()
    {
        selectedBox.enabled = false;
    }

    public void SetHeldSlot(InventorySlot heldSlot)
    {
        this.heldSlot = heldSlot;
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