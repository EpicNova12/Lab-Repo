using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public PlayerController playerController;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    public void changePowerUp(PowerUp currentPowerUp)
    {
        if(currentPowerUp.type == 1)
        {
            Score.instance.scoreUp(5);
            Debug.Log("New Score is: " + Score.instance.getScore());
        }
        else if (currentPowerUp.type == 2)
        {
            playerController.walkSpeed = 15;
        }
        if (currentPowerUp.type != 2)
        {
            playerController.walkSpeed = 5;
        }
    }
}
