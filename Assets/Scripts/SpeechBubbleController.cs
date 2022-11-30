using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleController : MonoBehaviour
{
    SpriteRenderer speechBubbleSprite;
    void Start()
    {
        // Finds the speech bubble, then disables it until it's needed.
        speechBubbleSprite = GetComponent<SpriteRenderer>();
        speechBubbleSprite.enabled = false;
    }


    void ShowBubbleSprite ()
    {
        // Makes the speech bubble sprite visible again.
        speechBubbleSprite.enabled = true;
    }
}
