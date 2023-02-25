using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject item;
    [SerializeField] private int amount = 1;

    private SpriteRenderer ren;
    private BoxCollider2D coll;

    private bool pickedUp;
    // Start is called before the first frame update
    void Start()
    {
        ren = this.AddComponent<SpriteRenderer>();
        ren.sprite = item.inventoryIcon;
        
        coll = this.AddComponent<BoxCollider2D>();
        coll.isTrigger = true;

        this.transform.localScale *= item.inventoryIconScale;
    }

    private void SetupPickup()
    {
        
    }

    private bool recentlyPlaced;
    public void PlacePickupItem(ItemScriptableObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
        recentlyPlaced = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pickedUp || recentlyPlaced)
            return;
        
        var inventory = other.gameObject.GetComponent<PlayerInventoryManager>();
        if (inventory == null)
            return;

        var successful = inventory.AddItem(item, amount);

        if (!successful)
            return;
        
        pickedUp = true;
        
        StartCoroutine(DoPickup(other.transform));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var inventory = other.gameObject.GetComponent<PlayerInventoryManager>();
        if (inventory == null)
            return;

        recentlyPlaced = false;
    }

    private IEnumerator DoPickup(Transform player)
    {
        float animationTime = 1f;
        LeanTween.scale(this.gameObject, Vector3.zero, animationTime);
        LeanTween.move(this.gameObject, player, animationTime);

        yield return new WaitForSeconds(animationTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
