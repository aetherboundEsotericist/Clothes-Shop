using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Equipment;
        description = "This is an equipment.";
    }
}
