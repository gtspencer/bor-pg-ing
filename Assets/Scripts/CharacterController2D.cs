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

    private Vector2 currentMotion;

    private Vector2 lastMotion;

    private bool moving;

    [SerializeField]
    private float maxInteractionDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPlayerInputs();
        
        
    }

    private void ProcessPlayerInputs()
    {
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
            lastMotion = new Vector2(horizontalAxis, verticalAxis).normalized;
            
            anim.SetFloat("lastHorizontal", horizontalAxis);
            anim.SetFloat("lastVertical", verticalAxis);
        }
    }

    private void TryInteract()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        var interactable = hit.collider.gameObject.GetComponent<IInteractable>();
        
        if (interactable != null && Vector2.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            interactable.Interact();
        
        Debug.LogError(hit.collider.gameObject.name);
        
        /*Debug.LogError("try interact");
        var hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        Debug.DrawLine(transform.position, Vector3.up);
        foreach (Collider2D c in hits)
        {
            Debug.LogError(c.gameObject.name);
            var interactable = c.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                return;
            }
        }*/
        
        
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
