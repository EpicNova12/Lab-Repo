using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    int currentScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void scoreUp(int amount)
    {
        currentScore = currentScore + amount;
    }
}
