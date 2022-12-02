using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static event Action<List<InventoryData>, int> OnInventoryChange;
    //public delegate void HandleInventoryUpdate(List<InventoryData> inventory, int inventoryID);

    [SerializeField] public int internalInventoryID;
    public List<InventoryData> inventory = new List<InventoryData>();
    private Dictionary<ItemData, InventoryData> itemDictionary = new Dictionary<ItemData, InventoryData>();


    void Start()
    {
        OnInventoryChange?.Invoke(inventory, internalInventoryID);
    }

    public void AddItem(ItemData itemData)
    {
        // Does this exist in the dictionary?
        if (itemDictionary.TryGetValue(itemData, out InventoryData item))
        {
            // Then add one to the stack
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory, internalInventoryID);
        }
        // If not, create the item and add it to the list and dictionary
        else
        {
            InventoryData newItem = new InventoryData(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            OnInventoryChange?.Invoke(inventory, internalInventoryID);
        }
    }

    public void RemoveItem(ItemData itemData)
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
            OnInventoryChange?.Invoke(inventory, internalInventoryID);
        }
    }
}
