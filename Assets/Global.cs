using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Is it bad practice to store global variables in a GameObject? Let's find out!
public class Global : MonoBehaviour
{
    [SerializeField] HideMenu NPCShopMenu;
    public bool isShopHidden = true;

    void Start ()
    {
        isShopHidden = NPCShopMenu.isHidden;
    }
}
