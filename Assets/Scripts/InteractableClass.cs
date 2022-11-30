using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class InteractableClass : MonoBehaviour
{
    SpriteRenderer speechBubbleSprite;

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
    }
}
