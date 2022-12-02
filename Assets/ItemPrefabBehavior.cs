/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPrefabBehavior : MonoBehaviour
{
    public InventoryObject inventory;
    public int itemAmount;
    public int inventoryPosition;
    TextMeshProUGUI textField;
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inventory.Container[inventoryPosition].amount);

        if(inventory.Container[inventoryPosition].amount <= 0)
        {
            Debug.Log("amount at 0, destroying...");
            Destroy(gameObject);
        }

        textField.text = inventory.Container[inventoryPosition].amount.ToString("n0");
    }

    public void updateItemAmount(int _amount)
    {
        itemAmount = _amount;
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
*/