using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    [SerializeField] private Image spriteImage;
    // Start is called before the first frame update
    void Start()
    {
        // TODO PUT THIS ON ALL INVENTORY SLOTS AND HOOKUP
    }

    // Update is called once per frame
    void Update()
    {
        
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
        spriteImage.sprite = sprite;
        
        if (sprite == null)
            spriteImage.color = Color.gray;
        else
            spriteImage.color = new Color(1, 1, 1, 1);
    }
}
