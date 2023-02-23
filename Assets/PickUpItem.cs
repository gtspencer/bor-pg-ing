using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PickUpItem : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject item;
    [SerializeField] private float scale = 1;

    private SpriteRenderer renderer;
    private Collider2D collider;

    private bool pickedUp;
    // Start is called before the first frame update
    void Awake()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<Collider2D>();
        
        collider.isTrigger = true;

        renderer.sprite = item.inventoryIcon;

        this.transform.localScale *= scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("hit " + other.gameObject.name);
        if (pickedUp)
            return;
        
        Debug.LogError("1");
        var inventory = other.gameObject.GetComponent<Inventory>();
        if (inventory == null)
            return;

        Debug.LogError("2");

        if (!inventory.CanPickupItem(item))
            return;
        
        Debug.LogError("3");
        inventory.AddItem(item);
        pickedUp = true;
        
        StartCoroutine(DoPickup(other.transform));
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
