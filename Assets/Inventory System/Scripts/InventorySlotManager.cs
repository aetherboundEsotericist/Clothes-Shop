using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlotManager : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemStackSize;

    public void ClearSlot()
    {
        itemIcon.enabled = false;
        itemStackSize.enabled = false;
    }

    public void DrawSlot(InventoryData item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        itemIcon.enabled = true;
        itemStackSize.enabled = true;

        itemIcon.sprite = item.itemData.displayIcon;
        itemStackSize.text = item.stackSize.ToString("n0");


    }
}
