using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScreenManager : MonoBehaviour
{
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
        
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i ++)
        {
            // Instantiates the item's preview prefab on the inventory
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMNS)), 0f);
    }
}
