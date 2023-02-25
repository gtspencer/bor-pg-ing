using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryScriptableObject inventory;
    public GameObject itemSlotPrefab;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;

    public int NUMBER_OF_COLUMN;

    public int Y_SPACE_BETWEEN_ITEM;

    private Dictionary<InventorySlot, GameObject> itemsDisplayed =
        new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }

    private void OnEnable()
    {
        UpdateDisplay();
    }

    private void CreateNewSlot(int i)
    {
        var itemSlot = Instantiate(itemSlotPrefab, Vector3.zero, Quaternion.identity, transform);
        itemSlot.GetComponentInChildren<Image>().sprite = inventory.Container[i].item.inventoryIcon;

        itemSlot.GetComponent<RectTransform>().localPosition = GetPosition(i);
        itemSlot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        itemsDisplayed.Add(inventory.Container[i], itemSlot);
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)),
            Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                CreateNewSlot(i);
            }
        }
    }
}
