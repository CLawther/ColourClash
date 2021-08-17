using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    //Using a singleton other objects can access to match player's colour value
    public static ColourChanger instance;

    public Renderer rend;

    //String used for player's colour
    public string PlayerColour;

    //Integer to determine a value for player's colour
    public int colourvalue;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter( Collider Player)
    {
        if(Player.CompareTag("GPickUp"))
        {
            //Changing player's colour to green when it collides with the green pick up using tags
            PlayerColour = "Green";
            colourvalue = 1;
            rend.material.color = Color.green;
        }

        if (Player.CompareTag("RPickUp"))
        {
            //Changing player's colour to red when it collides with the red pick up using tags
            PlayerColour = "Red";
            colourvalue = 2;
            rend.material.color = Color.red;
        }

        if (Player.CompareTag("YPickUp"))
        {
            //Changing player's colour to yellow when it collides with the yellow pick up using tags
            PlayerColour = "Yellow";
            colourvalue = 3;
            rend.material.color = Color.yellow;
        }

        if (Player.CompareTag("MPickUp"))
        {
            //Changing player's colour to magenta when it collides with the magenta pick up using tags
            PlayerColour = "Magenta";
            colourvalue = 4;
            rend.material.color = Color.magenta;
        }

        if (Player.CompareTag("BPickUp"))
        {
            //Changing player's colour to blue when it collides with the blue pick up using tags
            PlayerColour = "Blue";
            colourvalue = 5;
            rend.material.color = Color.blue;
        }


    }
}
