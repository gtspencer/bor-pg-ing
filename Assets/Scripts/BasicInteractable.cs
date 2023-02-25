using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(InteractionData interactionData)
    {
        LeanTween.scale(gameObject, Vector3.one * 1.2f, 1f).setEasePunch();
    }
}
