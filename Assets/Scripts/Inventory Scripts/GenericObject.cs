using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Generic Item", menuName = "Inventory System/Items/Generic")]
public class GenericObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Generic;
        description = "This is a generic item.";
    }
}
