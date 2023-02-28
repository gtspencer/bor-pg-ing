using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private float speed = 2f;

    private PlayerStateMachine playerStateMachine;
    [SerializeField]
    private InventoryScriptableObject inventory;

    [SerializeField] private GameObject inventoryUI;

    private Vector2 currentMotion;

    // private Vector2 lastMotion;

    private bool moving;

    private InventorySlot currentSelectedSlot;

    [SerializeField]
    private float maxInteractionDistance = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerStateMachine = GetComponent<PlayerStateMachine>();

        if (inventory == null)
            Debug.LogError("inventory is null on start");
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPlayerInputs();
    }

    private void ProcessPlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
        
        if (Input.GetMouseButtonDown(0))
            TryInteract();
            
        var horizontalAxis = Input.GetAxisRaw("Horizontal");
        var verticalAxis = Input.GetAxisRaw("Vertical");
        currentMotion = new Vector2(horizontalAxis, verticalAxis);
        
        anim.SetFloat("horizontal", horizontalAxis);
        anim.SetFloat("vertical", verticalAxis);

        moving = horizontalAxis != 0 || verticalAxis != 0;
        anim.SetBool("moving", moving);
        
        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            // lastMotion = new Vector2(horizontalAxis, verticalAxis).normalized;
            
            anim.SetFloat("lastHorizontal", horizontalAxis);
            anim.SetFloat("lastVertical", verticalAxis);
        }
    }

    private void ToggleInventory()
    {
        switch (playerStateMachine.currentState)
        {
            case PlayerStateMachine.States.Inventory:
                inventoryUI.SetActive(false);
                playerStateMachine.currentState = PlayerStateMachine.States.Roam;
                break;
            default:
                inventoryUI.SetActive(true);
                playerStateMachine.currentState = PlayerStateMachine.States.Inventory;
                break;
        }
    }

    private void TryInteract()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
        if (!hit)
            return;

        var interactable = hit.collider.gameObject.GetComponent<IInteractable>();

        if (interactable != null && Vector2.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
        {
            if (currentSelectedSlot.item is ToolScriptableObject)
            {
                // TODO tool logic
            }
            else
            {
                // pass in the inventory slot that is held
                // interactable object removes amount from slot
                InteractionData interactionData = new InteractionData(currentSelectedSlot);
                interactable.Interact(interactionData);
            }

            Debug.Log("User clicked interactable: " + hit.collider.gameObject.name);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = currentMotion * speed;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError(eventData.pointerClick.gameObject.name);
    }
}
