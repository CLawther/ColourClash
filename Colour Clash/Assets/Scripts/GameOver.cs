using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Reference to player and empty transform attached to player
    public GameObject Player;
    public Transform Bounds;

    void Update()
    {
        //If player goes out of bounds off map y too far player will reload the demo
        if (Player.transform.position.y < -2)
        {
            //Making player's position equal to the bounds position as its attached to the player in order to reload scene
            this.Player.transform.position = Bounds.position;
            SceneManager.LoadScene("Demo");
        }
    }
}
