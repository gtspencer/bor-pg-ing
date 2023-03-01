using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCController2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private float speed = 2f;

    [SerializeField] private Transform target;

    private PlayerStateMachine playerStateMachine;
    [SerializeField]
    private InventoryScriptableObject inventory;

    private NavMeshAgent agent;

    private Vector2 currentMotion;

    // private Vector2 lastMotion;

    private bool moving;


    [SerializeField]
    private float maxInteractionDistance = 1.5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerStateMachine = GetComponent<PlayerStateMachine>();

        if (inventory == null)
            Debug.LogError("inventory is null on start");
    }
    
    void Start()	{
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }

    private void FixedUpdate()
    {
        // Move();
    }

    private void Move()
    {
        rb.velocity = currentMotion * speed;
    }
}
