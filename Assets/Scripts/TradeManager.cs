using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// This manager should be attached to shop NPCs
public class TradeManager : MonoBehaviour
{
    public static event Action<int> ExternalRefreshInventory;
    [SerializeField] public InventoryScript playerInventory;
    public InventoryScript shopInventory;
    [SerializeField] public HideMenu shopHideMenu;

    private void OnEnable()
    {
        ItemButtonLogic.OnExternalTradeAttempt += Trade;
    }

    void Start()
    {
        shopInventory = GetComponent<InventoryScript>();
    }

    public void Trade(int slotPosition)
    {
        Debug.Log("here");
        if(shopInventory.inventory[slotPosition].itemData.itemPrice <= playerInventory.currentGold)
        {
            // Checks if the trade is legal.
            Debug.Log("item costs " + shopInventory.inventory[slotPosition].itemData.itemPrice + " and player has " + playerInventory.currentGold);
            Debug.Log("can trade!");

            // Subtracts gold from the player.
            playerInventory.currentGold -= shopInventory.inventory[slotPosition].itemData.itemPrice;

            // Adds item to the player's inventory, then removes the item from the shop.
            // Refreshing the inventories mid trade will cause variables to reset and the trade will fail.
            // To avoid that, the "refresh" bool parameter on both AddItem and RemoveItem must be set to false.
            playerInventory.AddItem(shopInventory.inventory[slotPosition].itemData, false);
            shopInventory.RemoveItem(shopInventory.inventory[slotPosition].itemData, false);

            // Forces a refresh of both inventories after the trade is done. (Not working, only first refresh is called)
            ExternalRefreshInventory?.Invoke(shopInventory.internalInventoryID);
            //ExternalRefreshInventory?.Invoke(playerInventory.internalInventoryID);
        }
    }
}
