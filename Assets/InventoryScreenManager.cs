/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScreenManager : MonoBehaviour
{
    //public GameObject inventoryPrefab;
    public InventoryObject inventory;

    public float X_START;
    public float Y_START;
    public float X_SPACE_BETWEEN_ITEMS;
    public float Y_SPACE_BETWEEN_ITEMS;
    public float NUMBER_OF_COLUMNS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i ++)
        {
            // Instantiates the item's preview prefab on the inventory
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            obj.GetComponent<ItemPrefabBehavior>().inventory = inventory;
            obj.GetComponent<ItemPrefabBehavior>().inventoryPosition = i;
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                Debug.Log(inventory.Container[i] + "exists");
            }
            else
            {
                Debug.Log(inventory.Container[i] + "doesn't exist");
            }
        }
        Debug.Log("complete");
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMNS)), 0f);
    }
}

/*
if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<ItemPrefabBehavior>().updateItemAmount(inventory.Container[i].amount);
                //itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, this.transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
                
                obj.GetComponent<ItemPrefabBehavior>().inventory = inventory;
                obj.GetComponent<ItemPrefabBehavior>().inventoryPosition = i;
                break;
            }
*/