//*********************************************************************************************************************
// File: Player.cs
//
// Description:
// This class handles the player componet of the game:
// - Button Presses
//*********************************************************************************************************************


using UnityEngine;

public class Player : MonoBehaviour
{
    public Ship playerShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonPushDown();
    }

    private void ButtonPushDown()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerShip.MoveForward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerShip.Turn(Ship.rotationDirection.LEFT);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerShip.Turn(Ship.rotationDirection.RIGHT);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerShip.Fire();
        }
    }
}
