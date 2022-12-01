using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Generic,
    Equipment
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,15)]
    public string description;

}
