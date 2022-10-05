using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int type; //1 = Yellow (Points) 2 = Blue (Speed)
    public string powerName;

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
