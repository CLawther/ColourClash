using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movementspeed;

    public Rigidbody myrb;

    // Start is called before the first frame update
    void Start()
    {
        movementspeed = 20f;

        myrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //by pressing up arrow can move player forwards
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, 0f, -movementspeed) * Time.deltaTime;
        }

        //by pressing down arrow can move player backwards
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, 0f, movementspeed) * Time.deltaTime;
        }

        //by pressing left arrow player can move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-movementspeed, 0f, 0f) * Time.deltaTime;
        }

        //by pressing right arrow player can move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(movementspeed, 0f, 0f) * Time.deltaTime;
        }

    }
}
