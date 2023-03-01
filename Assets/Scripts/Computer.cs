using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    private void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    [SerializeField] private GameObject computerHud;
    public void Interact(InteractionData interactionData)
    {
        computerHud.SetActive(true);
    }
}
