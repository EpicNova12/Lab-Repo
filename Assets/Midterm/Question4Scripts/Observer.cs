using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wants to know when another object does something interesting 
public abstract class Observer 
{
    public abstract void OnNotify();
}

public class AmbulanceSystem : Observer
{
    //The box gameobject which will do something
    GameObject ambulance;
    //What will happen when this box gets an event
    AmbulanceEvent ambulanceEvent;

    public AmbulanceSystem(GameObject ambulance, AmbulanceEvent ambulanceEvent)
    {
        this.ambulance = ambulance;
        this.ambulanceEvent = ambulanceEvent;
    }

    //What the box will do if the event fits it (will always fit but you will probably change that on your own)
    public override void OnNotify()
    {
        NotifyPlayer();
        ambulanceEvent.Move();
    }

    //The box will always jump in this case
    void NotifyPlayer()
    {
        //If the box is close to the ground
        Debug.Log("The Ambulance has arrived!!!");
    }
}
