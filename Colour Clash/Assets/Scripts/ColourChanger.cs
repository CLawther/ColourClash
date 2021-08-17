using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    //Reference to player
    public GameObject Player;
    //Using a singleton other objects can access to match player's colour value
    public static ColourChanger instance;

    public Renderer rend;

    //String used for player's colour
    public string PlayerColour;

    //Integer to determine a value for player's colour
    public int value;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter()
    {
        if(Player)
        {
            //Changing player's colour to green when it collides with the green pick up
            PlayerColour = "Green";
            value = 1;
            rend.material.color = Color.green;
        }
    }
}
