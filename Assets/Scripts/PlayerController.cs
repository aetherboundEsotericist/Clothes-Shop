using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    [SerializeField] float moveSpeed = 2f;
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
