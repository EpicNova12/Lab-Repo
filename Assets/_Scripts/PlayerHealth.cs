using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int health;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int getHealth()
    {
        return health;
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
