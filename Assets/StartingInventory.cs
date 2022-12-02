using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Initializes the shop's inventory. A bit hacky.
public class StartingInventory : MonoBehaviour
{
    public InventoryScript shopInventory;
    [SerializeField] public ItemData item1;
    [SerializeField] public int item1Amount;
    [SerializeField] public ItemData item2;
    [SerializeField] public int item2Amount;
    [SerializeField] public ItemData item3;
    [SerializeField] public int item3Amount;

    void Start()
    {
        shopInventory = GetComponent<InventoryScript>();
        StartInventory(item1, item1Amount);
        StartInventory(item2, item2Amount);
        StartInventory(item3, item3Amount);
    }

    public void StartInventory(ItemData item, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            shopInventory.AddItem(item,false);
        }
    }
}
