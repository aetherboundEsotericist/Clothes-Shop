using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Inventory System/Item")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public Sprite displayIcon;
}
