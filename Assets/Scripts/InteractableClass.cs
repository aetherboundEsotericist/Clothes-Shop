using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class InteractableClass : MonoBehaviour
{
    SpriteRenderer speechBubbleSprite;
    [SerializeField] ItemData itemToGive;

    public bool isInInteractionRange;

    void Start()
    {
        // Finds the speech bubble sprite, then disables it until it's needed.
        speechBubbleSprite = GetComponent<SpriteRenderer>();
        speechBubbleSprite.enabled = false;

        isInInteractionRange = false;
    }


    void Update()
    {
        if (isInInteractionRange)
        {
            speechBubbleSprite.enabled = true;
        }
        else speechBubbleSprite.enabled = false;
    }

    public void Interact()
    {
        Debug.Log("Interaction!");

        // This script is attached to the Interactable, the inventory belongs to the parent NPC.
        InventoryScript shopInventory = GetComponentInParent<InventoryScript>();
        shopInventory.AddItem(itemToGive);
    }
}
