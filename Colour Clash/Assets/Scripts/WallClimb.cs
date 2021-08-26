using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    //Using layer mask to add to walls to determine what is a wall
    public LayerMask WhatIsClimbable;
    public float climbforce;
    public float climbspeed;
    public bool isWallRight, isWallLeft, isWallUp, isWallDown;
    public bool isClimbing;
    public Rigidbody pRB;

    public Transform direction;

    void Start()
    {
        //Setting climb speed and force to be 6 at start
        climbspeed = 6f;
        climbforce = 6f;
    }

    void Update()
    {
        //Calling methods to be used later
        WallCheck();
        WallClimbInput();
    }

    private void WallClimbInput()
    {
        //If player is moving with A and D keys and raycast has detected a wall to the right or left start the wall run method
        if (Input.GetKeyDown(KeyCode.D) && isWallRight) StartWallClimb();
        if (Input.GetKeyDown(KeyCode.A) && isWallLeft) StartWallClimb();
        //If player is moving with W and S keys and raycast has detected a wall up or down start the wall run method
        if (Input.GetKeyDown(KeyCode.W) && isWallUp) StartWallClimb();
        if (Input.GetKeyDown(KeyCode.S) && isWallDown) StartWallClimb();

    }

    private void StartWallClimb()
    {
        //Turning off player's rigidbody gravity when player is climbing a wall
        pRB.useGravity = false;
        isClimbing = true;

        if (pRB.velocity.magnitude <= climbspeed)
        {
            //Adding force when wall running using the opposite direction to make player stick to the wall from any direction
            if(isWallRight)
            pRB.AddForce(direction.right * climbforce / 6 * Time.deltaTime);
            else
            {
                pRB.AddForce(-direction.right * climbforce / 6 * Time.deltaTime);
            }
            if(isWallUp)
            {
                pRB.AddForce(direction.up * climbforce / 6 * Time.deltaTime);
            }
            else
            {
                pRB.AddForce(-direction.up * climbforce / 6 * Time.deltaTime);
            }
        }

    }

    private void StopWallClimb()
    {
        //Turning back on player's rigidbody when player is no longer climbing a wall
        pRB.useGravity = true;
        isClimbing = false;
    }

    private void WallCheck()
    {
        //Using raycst to check if there is a wall to the right,left, up or down direction
        isWallRight = Physics.Raycast(transform.position, direction.right, 1.0f, WhatIsClimbable);
        isWallLeft = Physics.Raycast(transform.position, -direction.right, 1.0f, WhatIsClimbable);
        isWallUp = Physics.Raycast(transform.position, direction.up, 1.0f, WhatIsClimbable);
        isWallDown = Physics.Raycast(transform.position, -direction.up, 1.0f, WhatIsClimbable);

        //If no walls are detected via raycasts from any direction call the stop wall climb method
        if (!isWallRight && !isWallLeft && !isWallUp && isWallDown) StopWallClimb();
    }
}
