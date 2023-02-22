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
    // Start is called before the first frame update
    void Awake()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<Collider2D>();
        
        collider.isTrigger = true;

        renderer.sprite = item.inventoryIcon;

        this.transform.localScale *= scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
