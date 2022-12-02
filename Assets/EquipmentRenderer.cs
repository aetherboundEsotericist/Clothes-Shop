using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentRenderer : MonoBehaviour
{
    [SerializeField] public InventoryScript playerInventory;
    [SerializeField] public GameObject EquipmentObject;
    
    private void OnEnable()
    {
        ItemButtonLogic.onExternalEquipItem += EquipToggle;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EquipToggle(int slotPosition)
    {
        playerInventory.inventory[slotPosition].itemData.isEquipped = !playerInventory.inventory[slotPosition].itemData.isEquipped;
        GameObject equipment = Instantiate(EquipmentObject, gameObject.transform.position, Quaternion.identity, transform);
        SpriteRenderer equipmentRenderer = equipment.GetComponent<SpriteRenderer>();
        equipmentRenderer.sprite = playerInventory.inventory[slotPosition].itemData.displayIcon;

    }
}
