using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAmbulance : MonoBehaviour
{
    AmbulanceSystem Ambulance;
    PlayerAction inputAction;

    private void Awake()
    {
        inputAction = new PlayerAction();
        inputAction.Player.CallAmbulance.performed += cntxt => Notify();

    }
    public void Notify()
    {
        Ambulance.OnNotify();
    }
}
