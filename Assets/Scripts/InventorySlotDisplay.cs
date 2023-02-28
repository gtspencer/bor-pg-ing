using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    [SerializeField] private Image spriteImage;
    private InventorySlot heldSlot;
    public void SetHeldSlot(InventorySlot heldSlot)
    {
        this.heldSlot = heldSlot;
        
        if (heldSlot.item != null)
            UpdateSlotDisplay(heldSlot.item.inventoryIcon, heldSlot.amount);
        else
            UpdateSlotDisplay(null, 0);
    }

    public void UpdateSlotDisplay(Sprite sprite, int count)
    {
        SetImage(sprite);
        UpdateCountText(count);
    }

    public void UpdateCountText(int count)
    {
        if (count <= 1)
            countText.text = "";
        else
            countText.text = count.ToString("n0");
    }

    public void SetImage(Sprite sprite)
    {


        if (sprite == null)
        {
            spriteImage.color = Color.gray;
            spriteImage.sprite = null;
        }
        else
        {
            spriteImage.sprite = sprite;
            spriteImage.color = new Color(1, 1, 1, 1);
        }
    }
}
