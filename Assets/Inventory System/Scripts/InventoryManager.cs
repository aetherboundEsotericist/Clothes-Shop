using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public int interfaceInventoryID;
    [SerializeField] public bool isNPCShop;
    public GameObject slotPrefab;
    // Inventory is currently hard limited to 12. Size must be set here.
    public List<InventorySlotManager> inventorySlots = new List<InventorySlotManager>(12);

    private void OnEnable()
    {
        InventoryScript.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        InventoryScript.OnInventoryChange -= DrawInventory;
    }


    // Clears all slots
    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlotManager>(12);
    }

    // Erases the inventory, then draws it from scratch. Might be too heavy for larger inventories.
    void DrawInventory(List<InventoryData> inventory, int internalInventoryID)
    {
        if (internalInventoryID != interfaceInventoryID)
        {
            Debug.Log("IDs don't match, interface is: " + interfaceInventoryID + "and internal is: " + internalInventoryID);
            return;
        }

        Debug.Log("IDs match, interface is: " + interfaceInventoryID + "and internal is: " + internalInventoryID);
        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot(i);
        }

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot(int _slotPosition)
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);
        newSlot.GetComponent<InventorySlotManager>().slotPosition = _slotPosition;

        InventorySlotManager newSlotComponent = newSlot.GetComponent<InventorySlotManager>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }
}
