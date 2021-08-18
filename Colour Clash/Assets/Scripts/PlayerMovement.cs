using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController player;

    public float movespeed = 10.0f;
    public float jumppower = 20.0f;
    public float gravity = 30.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded;

    void Start()
    {
        //Getting player's character controller at start
        player = GetComponent<CharacterController>();
    }

    private void OnCollisionStay()
    {
        //Setting grounded to true
        isGrounded = true;
    }

    void Update()
    {
        //If player is grounded enabling vertical and horizontal movement
        if (player.isGrounded)
        {
            //Using Unity's built on axis so player can move with WASD or arrow keys
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= -movespeed;

            //When spacebar is pressed player jumps and if player is grounded
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                //Adding jump power when player jumps
                moveDirection.y = jumppower;
            }
        }

        //Appy gravity here whilst player is descending after jump multiplied by time delta time
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the player controller
        player.Move(moveDirection * Time.deltaTime);
    }
}
