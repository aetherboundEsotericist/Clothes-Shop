using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    [SerializeField] public int maxContainerSize;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            // If the inventory already has one of this item
            if(Container[i].item == _item)
            {
                // And it's an equipable
                
                if(Container[i].item.type == ItemType.Equipment)
                {
                    // Add it as a new item, since equipment should not stack
                    //Container.Add(new InventorySlot(_item, _amount));
                    //break;
                    Debug.Log("here");
                }
                // Else, just add to the stack
                else
                
                hasItem = true;
                Container[i].AddAmount(_amount);
                break;
            }
        }

        // If the inventory doesn't have the item, create it
        if (Container.Count >= maxContainerSize)
        {
            Debug.Log("inventory full");
        }
        else
        {
            if (!hasItem)
            {
                Container.Add(new InventorySlot(_item, _amount));
            }
        }
        
    }

    public void RemoveItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            // If the inventory still has this item
            if(Container[i].item == _item)
            {
                // And at least one unit
                if (Container[i].amount > 0)
                {
                    Container[i].RemoveAmount(_amount);

                    /*
                    // This currently breaks things down on the line.
                    if(Container[i].amount == 0)
                    Container.Remove(Container[i]);
                    

                    break;
                }

                
            }
        }
    }

    public string InspectItemInSlot(int containerSlot)
    {
        string itemName = Container[containerSlot].item.name;
        return itemName;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    // Adds the specified amount to an item stack.
    public void AddAmount(int value)
    {
        amount += value;
    }

    // Same as above but subtracts instead. It uses a different function for better readability.
    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}
*/