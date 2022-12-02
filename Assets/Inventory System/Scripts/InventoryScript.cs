using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int currentGold;
    public static event Action<List<InventoryData>, int> OnInventoryChange;
    //public delegate void HandleInventoryUpdate(List<InventoryData> inventory, int inventoryID);

    [SerializeField] public int internalInventoryID;
    public List<InventoryData> inventory = new List<InventoryData>();
    private Dictionary<ItemData, InventoryData> itemDictionary = new Dictionary<ItemData, InventoryData>();


    private void OnEnable()
    {
        ItemButtonLogic.OnExternalAddCall += TryAddItem;
        ItemButtonLogic.OnExternalRemoveCall += TryRemoveItem;
        ItemButtonLogic.OnExternalInspectCall += InspectItemInSlot;
        HideMenu.ExternalRefreshInventory += RefreshInventory;
        TradeManager.ExternalRefreshInventory += RefreshInventory;

    }

    private void OnDisable()
    {
        ItemButtonLogic.OnExternalAddCall -= TryAddItem;
        ItemButtonLogic.OnExternalRemoveCall -= TryRemoveItem;
        ItemButtonLogic.OnExternalInspectCall -= InspectItemInSlot;
        HideMenu.ExternalRefreshInventory -= RefreshInventory;
        TradeManager.ExternalRefreshInventory -= RefreshInventory;
    }

    void Start()
    {
        OnInventoryChange?.Invoke(inventory, internalInventoryID);
    }

    public void AddItem(ItemData itemData, bool refresh = true)
    {
        // Does this exist in the dictionary?
        if (itemDictionary.TryGetValue(itemData, out InventoryData item))
        {
            // Then add one to the stack
            item.AddToStack();

            if(refresh)
            {
                Debug.Log("AddItem's refresh parameter is: " + refresh);
                OnInventoryChange?.Invoke(inventory, internalInventoryID);
            }
        }
        // If not, create the item and add it to the list and dictionary
        else
        {
            InventoryData newItem = new InventoryData(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            
            if(refresh)
            {
                
                OnInventoryChange?.Invoke(inventory, internalInventoryID);
            }
            
        }
        Debug.Log("AddItem's refresh parameter is: " + refresh);
    }

    public void RemoveItem(ItemData itemData, bool refresh = true)
    {
        // Does this exist in the dictionary?
        if (itemDictionary.TryGetValue(itemData, out InventoryData item))
        {
            // Then remove one from the stack
            item.RemoveFromStack();
            // If the stack is empty, remove it from the list and dictionary
            if (item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }

            if(refresh)
            {
                OnInventoryChange?.Invoke(inventory, internalInventoryID);
            }
            Debug.Log("RemoveItem's refresh parameter is: " + refresh);
        }
    }

    public void TryAddItem(ItemData itemData, int callerID)
    {
        if (callerID == internalInventoryID)
        {
            Debug.Log("trying to add item");
            AddItem(itemData);
        }
    }

    public void TryRemoveItem(ItemData itemData, int callerID)
    {
        if (callerID == internalInventoryID)
        {
            Debug.Log("trying to remove item");
            RemoveItem(itemData);
        }
    }

    public void InspectItemInSlot(int slotPosition)
    {
        Debug.Log(inventory[slotPosition].itemData.displayName);
        //(inventory[slotPosition].itemData);
    }

    public void RefreshInventory(int callerID)
    {
        if(callerID == internalInventoryID)
        {
            Debug.Log("refreshing inventory: " + internalInventoryID);
            OnInventoryChange?.Invoke(inventory, internalInventoryID);
        }
    }
    //public void TradeItems()
}
