using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayGold : MonoBehaviour
{
    [SerializeField] public InventoryScript playerInventory;
    [SerializeField] public TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = playerInventory.currentGold.ToString("n0");
    }
}
