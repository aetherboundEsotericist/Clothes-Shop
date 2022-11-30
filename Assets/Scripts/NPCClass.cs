using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass : MonoBehaviour
{
    public string characterName = "??";

    GameObject playerReference;

    void Start ()
    {
        // This will find the player on the scene. 
        playerReference = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        {
            
        }
    }

    public void StartDialogue ()
    {
        Debug.Log("This is some dialogue!");
    }
}
