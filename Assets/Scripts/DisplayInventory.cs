using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public PlayerInventoryManager inventoryManager;
    public InventoryScriptableObject inventory;
    public GameObject itemSlotPrefab;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;

    public int NUMBER_OF_COLUMN;

    public int Y_SPACE_BETWEEN_ITEM;

    // gameobject is inventory slot prefab
    private Dictionary<GameObject, InventorySlot> itemsDisplayed =
        new Dictionary<GameObject, InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
        
        AddSwapEvent(gameObject, EventTriggerType.PointerEnter, delegate(BaseEventData arg0) { EnterInventoryScreen(); });
        AddSwapEvent(gameObject, EventTriggerType.PointerExit, delegate(BaseEventData arg0) { ExitInventoryScreen(); });
    }

    private GameObject CreateNewSlot(int i)
    {
        var itemSlot = Instantiate(itemSlotPrefab, Vector3.zero, Quaternion.identity, transform);

        itemSlot.GetComponent<RectTransform>().localPosition = GetPosition(i);

        SetSlotInfo(itemSlot, inventory.Container[i]);

        return itemSlot;
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)),
            Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

    private void SetSlotInfo(GameObject slotObject, InventorySlot slotData)
    {
        if (slotData.item == null)
        {
            slotObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
            var image = slotObject.GetComponentInChildren<Image>();
            image.sprite = null;
            image.color = Color.gray;
        }
        else
        {
            slotObject.GetComponentInChildren<TextMeshProUGUI>().text = slotData.amount <= 1 ? "" : slotData.amount.ToString("n0");
            var image = slotObject.GetComponentInChildren<Image>();
            image.sprite = slotData.item.inventoryIcon;
            image.color = new Color(1, 1, 1, 1);
        }
    }

    private void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> slot in itemsDisplayed)
        {
            SetSlotInfo(slot.Key, slot.Value);
        }
    }

    private void AddSwapEvent(GameObject itemSlot, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = itemSlot.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        
        trigger.triggers.Add(eventTrigger);
    }

    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventory.Container.Length; i++)
        {
            var slot = CreateNewSlot(i);
            
            AddSwapEvent(slot, EventTriggerType.PointerEnter, delegate(BaseEventData arg0) { OnEnter(slot); });
            AddSwapEvent(slot, EventTriggerType.PointerExit, delegate(BaseEventData arg0) { OnExit(slot); });
            AddSwapEvent(slot, EventTriggerType.BeginDrag, delegate(BaseEventData arg0) { OnDragStart(slot); });
            AddSwapEvent(slot, EventTriggerType.EndDrag, delegate(BaseEventData arg0) { OnDragEnd(slot); });
            AddSwapEvent(slot, EventTriggerType.Drag, delegate(BaseEventData arg0) { OnDrag(slot); });
            
            itemsDisplayed.Add(slot, inventory.Container[i]);
        }
    }

    private MouseItem mouseItem = new MouseItem();
    private void OnEnter(GameObject slot)
    {
        mouseItem.hoverObject = slot;
        if (itemsDisplayed.ContainsKey(slot))
            mouseItem.hoverItem = itemsDisplayed[slot];
    }
    
    private void OnExit(GameObject slot)
    {
        mouseItem.hoverObject = null;
        mouseItem.hoverItem = null;
    }
    
    private void OnDragStart(GameObject slot)
    {
        if (itemsDisplayed[slot].item == null)
            return;
        
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(40, 40);
        mouseObject.transform.SetParent(transform.parent);

        var img = mouseObject.AddComponent<Image>();
        img.sprite = itemsDisplayed[slot].item.inventoryIcon;
            
        // mouse ignores object
        img.raycastTarget = false;

        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[slot];
    }
    
    private void OnDragEnd(GameObject slot)
    {
        if (mouseItem.obj == null)
            return;
        
        if (mouseItem.hoverObject)
        {
            // item can be placed in slot
            inventory.MoveItems(itemsDisplayed[slot], itemsDisplayed[mouseItem.hoverObject]);
        }
        else
        {
            // item is hovering over inventory screen
            if (mouseInInventory)
            {
                Destroy(mouseItem.obj);
                mouseItem.item = null;
                return;
            }
            
            // remove item
            inventoryManager.DropItem(itemsDisplayed[slot].item, itemsDisplayed[slot].amount);
            inventory.RemoveItem(itemsDisplayed[slot].item, itemsDisplayed[slot].amount);
        }
        Destroy(mouseItem.obj);
        mouseItem.item = null;
    }
    
    private void OnDrag(GameObject slot)
    {
        if (mouseItem.obj != null)
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
    }

    private bool mouseInInventory;
    private void ExitInventoryScreen()
    {
        mouseInInventory = false;
    }

    private void EnterInventoryScreen()
    {
        mouseInInventory = true;
    }
}

public class MouseItem
{
    // instance of dragged item
    public GameObject obj;
    // data of dragged item
    public InventorySlot item;
    // data of item to swap
    public InventorySlot hoverItem;
    // gameobject of item to swap
    public GameObject hoverObject;

}
