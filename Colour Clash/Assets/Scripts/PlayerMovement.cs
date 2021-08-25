using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myRB;

    public float jumpPower;
    public float movementSpeed;

    // Use this for initialization
    void Start()
    {
        //Getting player rigidbody at start
        myRB = GetComponent<Rigidbody>();
        //Setting player's move speed and jump power to 10 at start
        movementSpeed = 8f;
        jumpPower = 8f;
    }

    void Update()
    {
        // Making sure that if Player presses down space bar Player can jump and checking if player is grounded
        if (Grounded() && Input.GetKeyDown(KeyCode.Space))
        {
            myRB.velocity = new Vector3(myRB.velocity.x, jumpPower);
        }
    }

    //Using fixed update to run at frame time
    public void FixedUpdate()
    {
        //Using Unity's built in axis so player can move with arrow keys or WASD
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        myRB.MovePosition(transform.position - move * Time.deltaTime * movementSpeed);
    }

    //Creating a method to be used for detection of the ground using a raycast
    public bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f);
    }

}
