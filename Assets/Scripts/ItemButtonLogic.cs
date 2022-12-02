using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemButtonLogic : MonoBehaviour
{
    public bool isParentMenuHidden;
    public int parentMenuID;
    public bool isNPCShop;
    [SerializeField] public ItemData itemToGive; 

    
    public static event Action<ItemData, int> OnExternalAddCall;
    public static event Action<ItemData, int> OnExternalRemoveCall;
    public static event Action<int> OnExternalInspectCall;
    public static event Action<int> OnExternalTradeAttempt;
    public static event Action<int> onExternalEquipItem;

    void Start()
    {
        parentMenuID = GetComponentInParent<InventoryManager>().interfaceInventoryID;
        isParentMenuHidden = GetComponentInParent<HideMenu>().isHidden;
        // Does this button belong to an NPC shop?
        isNPCShop = GetComponentInParent<InventoryManager>().isNPCShop;
    }

    void Update()
    {
        isParentMenuHidden = GetComponentInParent<HideMenu>().isHidden;
    }
    public void ReallyObnoxiousMethod()
    {
        // If this button belongs to an NPC shop, run shop logic.
        if (isNPCShop)
        {
            Debug.Log("This belongs to a shop");
            Debug.Log("Slot position: " + GetComponentInParent<InventorySlotManager>().slotPosition);

            OnExternalTradeAttempt?.Invoke(GetComponentInParent<InventorySlotManager>().slotPosition);

            //ItemData item = OnExternalInspectCall?.Invoke(1);

            //OnExternalRemoveCall?.Invoke(, parentMenuID);
            //Debug.Log("working, calling OnExternalAddCall");
        }

        // If not, run player inventory logic.
        else
        {
            Debug.Log("This belongs to the player");
            Debug.Log("Slot position: " + GetComponentInParent<InventorySlotManager>().slotPosition);

            onExternalEquipItem?.Invoke(GetComponentInParent<InventorySlotManager>().slotPosition);

        }
    }
}
