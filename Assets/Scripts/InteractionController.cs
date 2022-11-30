using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    Collider2D interactionZone;
    InteractableClass interactableObjectInRange;

    // Start is called before the first frame update
    void Start()
    {
        interactionZone = GetComponent<Collider2D>();
    }

    // This might have some issues if the player is in range of multiple interactables
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.GetComponent<InteractableClass>())
        {
            interactableObjectInRange = other.transform.gameObject.GetComponent<InteractableClass>();
            interactableObjectInRange.isInInteractionRange = true;
            Debug.Log("it's an interactable");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.gameObject.GetComponent<InteractableClass>())
        {
            other.transform.gameObject.GetComponent<InteractableClass>().isInInteractionRange = false;
            Debug.Log("leaving collision");
        }
    }

    public void CallObjectInteraction()
    {
        if (interactableObjectInRange)
        {
            Debug.Log("Trying to interact...");
            interactableObjectInRange.Interact();
        }
    }
}
