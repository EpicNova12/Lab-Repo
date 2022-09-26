using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    public int health;

    private void Start()
    {

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Score.instance.scoreUp(2);
            Debug.Log("Score: " + Score.instance.getScore());
            //Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }
}
