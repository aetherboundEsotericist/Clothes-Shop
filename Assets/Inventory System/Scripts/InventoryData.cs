using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryData 
{
    public ItemData itemData;
    public int stackSize;

    public InventoryData(ItemData item)
    {
        itemData = item;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
        Debug.Log("Added to inventory, new amount is " + stackSize);
    }

    public void RemoveFromStack()
    {
        stackSize--;
        Debug.Log("Removed from inventory, new amount is " + stackSize);
    }
}
