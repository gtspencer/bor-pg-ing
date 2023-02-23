using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// different ui to display inventory item slot presentation item
public class HotBarSlotItem : MonoBehaviour
{
    [SerializeField] private RawImage selectedBox;

    public InventoryItemSlotPresentation inventoryItemPresentation;

    // Start is called before the first frame update
    void Awake()
    {
        selectedBox.enabled = false;

        inventoryItemPresentation = this.GetComponent<InventoryItemSlotPresentation>();
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
