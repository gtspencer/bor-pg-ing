using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject computerHud;
    public void Interact()
    {
        computerHud.SetActive(true);
    }
}
