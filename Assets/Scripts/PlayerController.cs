using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InteractionController interactor;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject inventoryInterface;
    Rigidbody2D playerRigidbody;
    float inputHorizontal;
    float inputVertical;

    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactor.CallObjectInteraction();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Abre/fecha inventário eeee");

            inventoryInterface.GetComponent<HideMenu>().ToggleHide(GetComponentInParent<InventoryScript>().internalInventoryID);
        }
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            playerRigidbody.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);
        }
        else // This will constantly force the player's velocity to 0 whenever there's no input. Works for movement, but should be reworked if anything else tries to move the player.
        {
            playerRigidbody.velocity = new Vector2(0,0);
        }
    }
}
