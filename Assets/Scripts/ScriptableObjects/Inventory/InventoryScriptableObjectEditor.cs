using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryScriptableObjectEditor : Editor
{
    private InventoryScriptableObject inventoryObject;
    
    private void OnEnable()
    {
        inventoryObject = target as InventoryScriptableObject;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        /*foreach (KeyValuePair<ItemScriptableObject.ItemType, InventorySlot> kv in inventoryObject.Container)
        {
            GUILayout.Label(kv.Key + " " + kv.Value.item.name + " " + kv.Value.amount, GUILayout.Height(40), GUILayout.Width(100));
        }*/
        
        
    }
}
