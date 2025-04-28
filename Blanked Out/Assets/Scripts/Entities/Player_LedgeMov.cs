using System.Collections;
using UnityEngine;

public class Player_LedgeMov : MonoBehaviour
{
    public Player_Movement movement; //Reference player movement to turn it on and off.
    public bool isHanging = true;

    //This is the movement script related to Ledge Grabbing, where you can only pull yourself up or drop down.
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //Drop down
            movement.enabled = true;
            this.enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Climb up
            movement.enabled = true;
            this.enabled = false;
        }
    }

}

